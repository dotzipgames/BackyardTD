using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TMPro.EditorUtilities;

public class PlayerCurrency : MonoBehaviour
{
    private int balance = 75;
    public float Balance
    {
        get { return balance; }
    }
    [SerializeField] private TMP_Text balanceText;

    public void Stonks()
    {
        balance += Random.Range(7, 13);
        balanceText.SetText("Balance: € " + balance + ",-");
    }
}
