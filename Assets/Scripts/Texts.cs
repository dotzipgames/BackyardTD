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
    void Update()
    {
        wavesText.SetText("Waves Left: " + Enemy.wavesleft);
        enemyText.SetText("Enemies Left: " + Enemy.spawnedEnemy);
    }
}