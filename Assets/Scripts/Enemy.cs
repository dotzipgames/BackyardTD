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

    public static List<GameObject> enemies;

    private bool endWave;

    void Awake()
    {
        enemies = new List<GameObject>();
        endWave = false;
    }
    void Start()
    {
        wavesleft = Random.Range(2, 5);
        NewWave();
        
    }

    void Update()
    {
        if (enemies.Count == 0 && endWave == false)
        {
            endWave = true;
            if (wavesleft == 0)
            {
                SceneManager.LoadScene("Wave Cleared");
            }
            else if (wavesleft != 0)
            {
                wavesleft--;
                NewWave();
            }
        }
    }
    
    void NewWave()
    {
        enemyCount = Random.Range(2, 7);
        StartCoroutine(CountdownNextWave());
    }

    IEnumerator Spawn()
    {
        wcGameObject.SetActive(false);
        for (int i = 0; i < enemyCount; i++)
        {
            
            GameObject instenemy = Instantiate(enemy, parent.transform);
            instenemy.GetComponent<EnemyMove>().Waypoints(waypoints);
            enemies.Add(instenemy);
            yield return new WaitForSeconds(delay);
        }
        endWave = false;
    }

    IEnumerator CountdownNextWave()
    {
        wcGameObject.SetActive(true);

        for (int i = 5; i > 0; i--)
        {
            wcText.SetText("Wave starts in: \n" + i + "\n Seconds.");
            yield return new WaitForSeconds(1);
        }
        
        StartCoroutine(Spawn());
        yield return null;
    }
}