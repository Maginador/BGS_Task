using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] ProductSO[] storeProducts;
    [SerializeField] GridButton gridButtonPrefab;
    [SerializeField] Transform storeGridRoot;
    [SerializeField] StorePreviewer previewer;
    private void Start(){
        BuildUI();
    }
    private void BuildUI(){
        for(int i =0; i < storeProducts.Length; i++){
            var button = Instantiate(gridButtonPrefab,storeGridRoot);
            button.Setupbutton(storeProducts[i], previewer.ShowPreview);
        }
    }
}
