using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class GridButton : MonoBehaviour
{
     [SerializeField] private Button button;
    [SerializeField] Image itemAsset;
    [SerializeField] TMP_Text itemPrice;
    ProductSO productData;


    public void Setupbutton(ProductSO product, UnityAction<ProductSO> storeAction){
        itemAsset.sprite = product.asset;
        itemPrice.text = product.price.ToString();
        productData = product;
        button.onClick.AddListener(() => storeAction.Invoke(product));
    }
}
