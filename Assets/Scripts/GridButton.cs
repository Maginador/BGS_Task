using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GridButton : MonoBehaviour
{
    [SerializeField] Image itemAsset;
    [SerializeField] TMP_Text itemPrice;
    ProductSO productData;


    public void Setupbutton(ProductSO product){
        itemAsset.sprite = product.asset;
        itemPrice.text = product.price.ToString();
        productData = product;
    }
}
