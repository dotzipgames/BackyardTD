using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lvl2 : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    private int enemyCount;

    [SerializeField] private float delay = 0.5f;
    public int wavesLeft;

    [SerializeField] private GameObject parent;
    [SerializeField] private Transform[] waypoints;
    public TextsLvl2 texts;
    public float spawnedEnemy;

    [SerializeField] private GameObject wcGameObject;
    [SerializeField] private TMP_Text wcText;

    [SerializeField] private GameObject startFirstWaveButton;

    public List<GameObject> enemies; 

    private bool endWave;
    public bool startGame = false;

    void Awake()
    {
        enemies = new List<GameObject>();
        endWave = false;
    }

    void Update()
    {
        if (startGame == true)
        {
            if (enemies.Count == 0 && endWave == false)
            {
                endWave = true;
                if (wavesLeft == 0)
                {
                    SceneManager.LoadScene("End Screen");
                }
                else if (wavesLeft != 0)
                {
                    wavesLeft--;
                    NewWave();
                }
            }
        }
    }

    public void StartFirstWave()
    {
        startFirstWaveButton.SetActive(false);
        wavesLeft = Random.Range(2, 5);
        texts.wavesText.enabled = true;
        texts.enemyText.enabled = true;
        NewWave();
    }

    void NewWave()
    {
        enemyCount = Random.Range(2, 7);
        StartCoroutine(CountdownNextWave());
    }

    IEnumerator Spawn()
    {
        wcGameObject.SetActive(false);
        startGame = true;

        for (int i = 0; i < enemyCount; i++)
        {

            GameObject instenemy = Instantiate(enemy, parent.transform);
            instenemy.GetComponent<EnemyMoveLvl2>().Waypoints(waypoints);
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