using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Texts : MonoBehaviour
{

    public Enemy Enemy;
    public EnemyMove EnemyMove;

    [SerializeField] private TMP_Text wavesText;
    [SerializeField] private TMP_Text enemyText;

    [SerializeField] private GameObject clearedBig;
    [SerializeField] private TMP_Text clearedBigT;
    [SerializeField] private GameObject clearedSmall;
    [SerializeField] private TMP_Text clearedSmallT;

    [SerializeField] private GameObject map;
    [SerializeField] private float delay = 1f;

    private int zero = 0;

    void Start()
    {
        clearedBig.SetActive(false);
        clearedSmall.SetActive(false);
    }
    void Update()
    {
        wavesText.SetText("Waves Left: " + Enemy.waves);
        enemyText.SetText("Enemies Left: " + Enemy.spawnedEnemy);
    }

    public void WaveCleared()
    {
        map.SetActive(false);
        clearedBig.SetActive(true);
        clearedSmall.SetActive(true);
        StartCoroutine(OneSecPls());
    }
    IEnumerator OneSecPls()
    {
        for (int t = 3; t > zero; t--)
        {
            if (t == 0)
            {
                t--;
                clearedBig.SetActive(false);
                clearedSmall.SetActive(false);
            }
            else
            {
                Debug.Log(t);
                clearedSmallT.SetText("The next round will start in " + t + " seconds.");
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
