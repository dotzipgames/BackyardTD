using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TMPro.EditorUtilities;

public class PlayerCurrency : MonoBehaviour
{
    private int balance = 175;
    public float Balance
    {
        get { return balance; }
    }
    [SerializeField] private TMP_Text balanceText;

    private void Start()
    {
        balanceText.SetText("Balance: € " + balance + ",-");
    }

    public void Stonks()
    {
        balance += Random.Range(15, 25);
        balanceText.SetText("Balance: € " + balance + ",-");
    }

    public void NFT_NoStonks()
    {
        balance -= 50;
        balanceText.SetText("Balance: € " + balance + ",-");
    }

    public void PMT_NoStonks()
    {
        balance -= 125;
        balanceText.SetText("Balance: € " + balance + ",-");
    }
}
