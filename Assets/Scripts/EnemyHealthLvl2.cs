using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyHealthLvl2 : MonoBehaviour
{
    private Lvl2 lvl2;
    [SerializeField] private float health = 10; //10 hp
    [SerializeField] private Transform healthbar;
    private PlayerCurrency playerCurrency;
    private float big = 0.4f;
    private Vector3 scale;

    void Start()
    {
        lvl2 = GameObject.Find("Enemy").GetComponent<Lvl2>();
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
            lvl2.enemies.Remove(gameObject);
            playerCurrency.Stonks();
            Destroy(gameObject);
        }
    }
}
