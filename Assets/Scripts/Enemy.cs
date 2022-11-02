using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    private int enemyCount;

    [SerializeField] private float delay = 0.5f;
    public int waves;

    [SerializeField] private GameObject parent;
    [SerializeField] private Transform[] waypoints;
    public Texts texts;
    public float spawnedEnemy;

    void Start()
    {
        //waves = Random.Range(2, 5);
        waves = 0;
        enemyCount = 1;
        //enemyCount = Random.Range(2, 7);
        StartCoroutine(Spawn());    }

    void Update()
    {
        while (waves < 0)
        {   
            Debug.Log("Enemies Left: " + spawnedEnemy);
            Debug.Log("Waves Left: " + waves);
        }

        
        if (spawnedEnemy == 0)
        {
            if (waves == 0)
            {
                waves--;
                Debug.Log("Last wave has ended.");
                texts.WaveCleared();
            }
            else if (waves != 0)
            {
                waves--;
                NewWave();
            }
        }
    }
    
    void NewWave()
    {
        //enemyCount = Random.Range(2, 7);
        enemyCount = 1;
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject instenemy = Instantiate(enemy, parent.transform);
            instenemy.GetComponent<EnemyMove>().Waypoints(waypoints);
            spawnedEnemy++;
            yield return new WaitForSeconds(delay);
        }
    }
}
