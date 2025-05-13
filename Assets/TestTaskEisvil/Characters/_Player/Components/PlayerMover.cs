using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _movement;
    private Vector3 _rotation;

    private void Update()
    {
        if (_rb)
        {
            _rb.position +=_movement;
            _rb.rotation *= Quaternion.Euler(_rotation);
        }

        _movement = Vector3.zero;
        _rotation = Vector3.zero;
    }

    public void Init(Rigidbody rigidbody)
    {
        _rb = rigidbody;
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