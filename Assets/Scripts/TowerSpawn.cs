using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerSpawn : MonoBehaviour
{
    [SerializeField] private bool isPlaced = false;
    [SerializeField] private bool collisionCheck = false;

    private SpriteRenderer sprite;
    private SpriteRenderer radiusRenderer;
    private PlayerCurrency playerCurrency;
    private MousePositionManager mousePositionManager;

    private Color normal;
    private Color red;

    private void Start()

    {
        sprite = GetComponent<SpriteRenderer>();
        radiusRenderer = GameObject.Find("Radius").GetComponent<SpriteRenderer>();
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
            isPlaced = true;
        }

            if (isPlaced == false)
        {
            Debug.Log("isPlaced: " + isPlaced);
            Debug.Log("collisionCheck: " + collisionCheck);
            transform.position = mousePositionManager.newPos;
        }

        if (isPlaced == true && collisionCheck == false)
        {
            gameObject.GetComponent<TowerAttack>().enabled = true;
            gameObject.GetComponent<Animator>().enabled = true;
            radiusRenderer.enabled = false;
            DeductBalance();
            Destroy(this);
        
        }
    }

    void DeductBalance()
    {
        if (gameObject.name == "Frog Tower(Clone)" && playerCurrency.Balance >= 50)
        {
            playerCurrency.NFT_NoStonks();
        }
        else if (gameObject.name == "Pink Man Tower(Clone)" && playerCurrency.Balance >= 125)
        {
            playerCurrency.PMT_NoStonks();
        }
        else if (gameObject.name == "Frog Tower(Clone)" && playerCurrency.Balance < 50 || gameObject.name == "Pink Man Tower(Clone)" && playerCurrency.Balance < 125)
        {
            Destroy(gameObject);
        }

    }
    void OnMouseDown()
    {
        isPlaced = true;
    }

    void OnCollisionEnter2D(Collision2D other)
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
