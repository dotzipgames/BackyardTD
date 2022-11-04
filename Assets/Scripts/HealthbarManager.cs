using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarManager : MonoBehaviour
{
    [SerializeField] private Image healthbarTop;

    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        healthbarTop.fillAmount = playerHealth.Health / 100;
    }
}
