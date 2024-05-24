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
    private bool enableInteraction;
    private List<Collider2D> triggers = new List<Collider2D>();
    private void Awake()
    {
        inputAction = new PlayerActions();
        inputAction.Actions.ContextAction.performed += DoInteraction;
        inputAction.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _interactionCue.SetActive(true);
        enableInteraction = true;
        triggers.Add(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _interactionCue.SetActive(false);
        enableInteraction = false;
        triggers.Remove(other);

    }

    private void DoInteraction(InputAction.CallbackContext context)
    {
        for (int i = 0; i < _triggerTags.Length; i++)
        {
            for (int o = 0; o < triggers.Count; o++)
            {
                if (triggers[o].CompareTag(_triggerTags[i]))
                {
                    _triggerEvents[i]?.Invoke();
                }

            }
        }

    }
}
