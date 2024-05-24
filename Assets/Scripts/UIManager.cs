using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] private GameObject storeCanvas;
    [SerializeField] private PlayerMovement player;
    public void OpenStore()
    {
        storeCanvas.SetActive(true);
        player.LockPlayerMovement(true);
    }

    public void CloseStore()
    {
        storeCanvas.SetActive(false);
        player.LockPlayerMovement(false);


    }
}
