using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shop;
    private bool isActive = false;

    public void OpenShop()
    {
        if (isActive == false)
        {
            shop.SetActive(true);
            isActive = true;
        }
        else if (isActive == true)
        {
            shop.SetActive(false);
            isActive = false;
        }
    }
}
