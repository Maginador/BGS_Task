using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] ProductSO[] storeProducts;
    [SerializeField] GridButton gridButtonPrefab;
    [SerializeField] Transform storeGridRoot;
    [SerializeField] StorePreviewer previewer;
    [SerializeField] UIManager uiManager;
    [SerializeField] GameObject purchaseButton;
    Dictionary<ProductSO, bool> purchasedProducts = new Dictionary<ProductSO, bool>();
    private void Start()
    {
        BuildUI();
    }
    private void BuildUI()
    {
        for (int i = 0; i < storeProducts.Length; i++)
        {
            var button = Instantiate(gridButtonPrefab, storeGridRoot);
            button.Setupbutton(storeProducts[i], previewer.ShowPreview);
        }
    }

    public void DoPurchase()
    {

        var so = previewer.GetCurrentProduct();
        Economy.Instance.SpendCurrency(so.price);
        purchasedProducts.Add(so, true);
        uiManager.CloseStore();
    }

    public void Update()
    {

        if (CanMakePurchase())
        {
            purchaseButton.SetActive(true);
        }
        else
        {
            purchaseButton.SetActive(false);
        }
    }

    private bool CanMakePurchase()
    {
        var so = previewer.GetCurrentProduct();
        if (so != null)
        {
            if (purchasedProducts.ContainsKey(so)) return false;
            else return true;
        }

        return false;
    }
}
