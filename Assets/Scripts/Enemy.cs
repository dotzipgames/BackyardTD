using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    private int enemyCount;

    [SerializeField] private float delay = 0.5f;
    public int wavesleft;

    [SerializeField] private GameObject parent;
    [SerializeField] private Transform[] waypoints;
    public Texts texts;
    public float spawnedEnemy;

    [SerializeField] private GameObject wcGameObject;
    [SerializeField] private TMP_Text wcText;

    void Start()
    {
        //wavesleft = Random.Range(2, 5);
        wavesleft = 1;
        enemyCount = 1;
        //enemyCount = Random.Range(2, 7);
        StartCoroutine(Spawn());
        
    }

    void Update()
    {
        if (spawnedEnemy == 0)
        {

            if (wavesleft == -1)
            {
                SceneManager.LoadScene("Wave Cleared");
            }
            else if (wavesleft != -1)
            {
                wavesleft--;
                NewWave();
            }
        }
    }
    
    void NewWave()
    {
        //enemyCount = Random.Range(2, 7);
        enemyCount = 1;
        StartCoroutine(CountdownNextWave());
    }

    IEnumerator Spawn()
    {
        wcGameObject.SetActive(false);
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject instenemy = Instantiate(enemy, parent.transform);
            instenemy.GetComponent<EnemyMove>().Waypoints(waypoints);
            spawnedEnemy++;
            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator CountdownNextWave()
    {
        wcGameObject.SetActive(true);

        for (int i = 5; i > 0; i--)
        {
            wcText.SetText("Next Wave: \n" + i + "\n Seconds.");
            yield return new WaitForSeconds(i);
        }
        
        StartCoroutine(Spawn());
        yield return null;
    }
}