using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    [SerializeField] private GameObject tower;
    private GameObject target;
    private bool canAttack = true;
    [SerializeField] private float damage = 5f;
    [SerializeField] private float attackCooldown = 0.8f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") == true && canAttack == true)
        {
            target = other.gameObject;
            Attack();
        }
    }

    void Attack()
    {
        if (canAttack == true)
        {
            canAttack = false;
            StartCoroutine(Cooldown());
            animator.SetTrigger("Attack");
            target.GetComponent<EnemyHealth>().TakeDmg(damage);
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
