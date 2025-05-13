using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInput : MonoBehaviour
{
    private GameInput _input;
    private Vector2 _moveInput;

    void Start()
    {
        _input = new GameInput();
        _input.Gameplay.Mouse.performed += OnMouse;
        _input.Enable();
    }

    private void OnMouse(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
        
        ResetInput();
    }

    private async UniTask ResetInput()
    {
        await UniTask.WaitForSeconds(0.1f);
        _moveInput = Vector2.zero;
    }

    private void Update()
    {
        Debug.Log("moveInputX: " + _moveInput.x + " MoveY " + _moveInput.y);
    }
}