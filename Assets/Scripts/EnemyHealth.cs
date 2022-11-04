using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health = 10; //10 hp
    [SerializeField] private Transform healthbar;
    private PlayerCurrency playerCurrency;
    private float big = 0.4f;
    private Vector3 scale;

    void Start()
    {
        playerCurrency = GameObject.Find("Player").GetComponent<PlayerCurrency>();
        scale = new Vector3(big, big, big);
    }

    public void TakeDmg(float damage)
    {
        health -= damage;
        scale.x = 4 * (health/100);

        healthbar.localScale = scale;

        if (health <= 0)
        {
            Enemy.enemies.Remove(gameObject);
            playerCurrency.Stonks();
            Destroy(gameObject);
        }
    }
}
