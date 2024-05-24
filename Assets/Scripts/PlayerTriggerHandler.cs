using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerTriggerHandler : MonoBehaviour
{
    [SerializeField] private string[] _triggerTags;
    [SerializeField] private UnityEvent[] _triggerEvents;
    [SerializeField] private GameObject _interactionCue;
    private PlayerActions inputAction;
    private void Awake()
    {
        inputAction = new PlayerActions();
        inputAction.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _interactionCue.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _interactionCue.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (inputAction.Actions.ContextAction.ReadValue<float>() > 0){
            for(int i = 0; i<_triggerTags.Length; i++){
            if(other.CompareTag(_triggerTags[i]))
            {
                _triggerEvents[i]?.Invoke();
            }
        }
        }
    }
}
