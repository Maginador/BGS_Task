using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerActions inputActions;

    [SerializeField] float movementSpeed, runSpeed;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private float updateThreashold = 0;
    void Awake()
    {
        inputActions = new PlayerActions();
        inputActions.Movement.Sprint.performed += OnSprint;
        inputActions.Movement.SlowWalk.performed += OnSlowdown;
        inputActions.Enable();

        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnSlowdown(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    private void OnSprint(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }
    void Update()
    {
        Vector2 moveInput = inputActions.Movement.Movement.ReadValue<Vector2>();
        var runInput = inputActions.Movement.Sprint.ReadValue<float>();
        Vector2 move = (1 + runInput) * Time.deltaTime * new Vector2(moveInput.x, moveInput.y);
        transform.Translate(move, Space.World);

        _animator.SetFloat("MoveSpeed", moveInput.magnitude);

        if (moveInput.magnitude > updateThreashold)
        {
            float direction;
            if (moveInput.y < 0) direction = .5f;
            else if (moveInput.y > 0) direction = 1;
            else
            {
                direction = 0;
                if (moveInput.x < 0) _spriteRenderer.flipX = true;
                else _spriteRenderer.flipX = false;
            }
            _animator.SetFloat("Direction", direction);
        }

    }
}
