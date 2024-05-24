using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    [SerializeField] private Transform _storeEntranceOut, _storeEntranceIn;

    public void TeleportToStore(){

        transform.position = _storeEntranceIn.position;
    }
   
   public void TeleportOutOfStore(){

        transform.position = _storeEntranceOut.position;
    }
}
