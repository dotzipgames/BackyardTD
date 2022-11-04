using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class WaveCleared : MonoBehaviour
{

    [SerializeField] private TMP_Text clearedSmallT;
    [SerializeField] private float delay = 1f;

    public void Start()
    {
        StartCoroutine(OneSecPls());
    }
    IEnumerator OneSecPls()
    {
        for (int t = 3; t > 0; t--)
        {
            clearedSmallT.SetText("The next level will start in " + t + " seconds.");
            yield return new WaitForSeconds(delay);
        }
        SceneManager.LoadScene("Level 2");
        yield return null;
    }
}
