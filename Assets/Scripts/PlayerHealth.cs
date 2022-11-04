using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float health = 100;
    public float Health
    {
        get { return health; }
    }

    public void TakeDmg(float dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
