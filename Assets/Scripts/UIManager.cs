using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject storeCanvas;
   public void OpenStore(){
    storeCanvas.SetActive(true);
   }

   public void CloseStore(){
    storeCanvas.SetActive(false);

   }
}
