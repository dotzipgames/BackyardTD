using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextsLvl2 : MonoBehaviour
{
    public Lvl2 Lvl2;
    public EnemyMove EnemyMove;

    public TMP_Text wavesText;
    public TMP_Text enemyText;

    private void Awake()
    {
        wavesText.enabled = false;
        enemyText.enabled = false;
    }
    void Update()
    {
        if (Lvl2.wavesLeft == 0)
        {
            wavesText.SetText("Last Wave!");
            enemyText.SetText("Enemies Left: " + Lvl2.enemies.Count);
        }
        else
        {
            wavesText.SetText("Waves Left: " + Lvl2.wavesLeft);
            enemyText.SetText("Enemies Left: " + Lvl2.enemies.Count);
        }
    }
}