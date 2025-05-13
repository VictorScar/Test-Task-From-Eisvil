using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private CharacterController _charController;
    private Vector3 _movement;
    private Vector3 _rotation;

    private void Update()
    {
        if (_charController)
        {
            _charController.Move(_movement);
            _charController.transform.Rotate(_rotation);
        }

        _movement = Vector3.zero;
        _rotation = Vector3.zero;
    }

    public void Init(CharacterController characterController)
    {
        _charController = characterController;
    }

    public void Move(float inputDirection, float moveSpeed)
    {
        _movement = transform.forward * inputDirection * moveSpeed * Time.deltaTime;
    }

    public void Rotate(float angle, float rotationSpeed)
    {
        _rotation = new Vector3(0, angle * rotationSpeed * Time.deltaTime, 0);
    }
}