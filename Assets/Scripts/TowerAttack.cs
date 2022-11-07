using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private bool canAttack = true;
    [SerializeField] private float damage = 5f;
    [SerializeField] private float attackCooldown = 0.8f;
    private Animator animator;
    private CircleCollider2D circleCollider;

    void Start()
    {
        animator = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.enabled = true;
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
            animator.SetTrigger("Attack");
            target.GetComponent<EnemyHealth>().TakeDmg(damage);
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
