using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shop;

    [SerializeField] private GameObject NFT, PMT;
    [SerializeField] private GameObject parent;

    private bool isActive;

    private void Start()
    {
        isActive = false;
        shop.SetActive(false);
    }

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

    public void SpawnNFT()
    {
        shop.SetActive(false);
        Instantiate(NFT, parent.transform);
    }

    public void SpawnPMT()
    {
        shop.SetActive(false);
        Instantiate(PMT, parent.transform);
    }

}
