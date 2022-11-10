using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerSpawnLvl2 : MonoBehaviour
{
    [SerializeField] private bool isPlaced = false;
    [SerializeField] private bool collisionCheck = false;

    [SerializeField] private SpriteRenderer radiusRenderer;

    private SpriteRenderer sprite;
    private PlayerCurrency playerCurrency;
    private MousePositionManager mousePositionManager;

    private Color normal;
    private Color red;

    private void Start()

    {
        sprite = GetComponent<SpriteRenderer>();
        playerCurrency = GameObject.Find("Player").GetComponent<PlayerCurrency>();
        mousePositionManager = GameObject.Find("Player").GetComponent<MousePositionManager>();

        red = new Color(1f, 0.3f, 0.3f, 1f);
        normal = new Color(1f, 1f, 1f, 1f);

        transform.position = Vector3.zero;

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (collisionCheck == false)
            {
                isPlaced = true;
            }
        }

        if (isPlaced == false)
        {
            transform.position = mousePositionManager.newPos;
        }

        if (isPlaced == true && collisionCheck == false)
        {
            radiusRenderer.enabled = false;
            gameObject.GetComponent<TowerAttackLvl2>().enabled = true;
            gameObject.GetComponent<Animator>().enabled = true;
            DeductBalance();
            Destroy(this);
        
        }
    }

    void DeductBalance()
    {
        if (gameObject.name == "Frog Tower Lvl2(Clone)" && playerCurrency.Balance >= 50)
        {
            playerCurrency.NFT_NoStonks();
        }
        else if (gameObject.name == "Pink Man Tower Lvl2(Clone)" && playerCurrency.Balance >= 125)
        {
            playerCurrency.PMT_NoStonks();
        }
        else if (gameObject.name == "Frog Tower Lvl2(Clone)" && playerCurrency.Balance < 50 || gameObject.name == "Pink Man Tower Lvl2(Clone)" && playerCurrency.Balance < 125)
        {
            Destroy(gameObject);
        }

    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Border")
        {
            collisionCheck = true;
            sprite.color = red;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        collisionCheck = false;
        sprite.color = normal;
    }
}
