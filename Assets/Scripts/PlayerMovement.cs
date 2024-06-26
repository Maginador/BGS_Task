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
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private float updateThreashold = 0;
    private  Vector2 move;
    private bool playerLocked;
    void Awake()
    {
        inputActions = new PlayerActions();
        inputActions.Enable();

        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();


    }

    void Update()
    {
        if(playerLocked) return;

        Vector2 moveInput = inputActions.Movement.Movement.ReadValue<Vector2>();
        var runInput = inputActions.Movement.Sprint.ReadValue<float>();
        move = (1 + runInput) * movementSpeed * Time.deltaTime * new Vector2(moveInput.x, moveInput.y);
        _rigidbody2D.
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
                if (moveInput.x < 0) transform.localScale = new Vector3(-1,1,1);
                else transform.localScale = Vector3.one;
            }
            _animator.SetFloat("Direction", direction);
        }

    }
    void FixedUpdate()
    {
        _rigidbody2D.velocity = move;
    }

    public void LockPlayerMovement(bool lockToggle){

        playerLocked = lockToggle;
    }
}
