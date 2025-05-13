using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachmentFixer : MonoBehaviour
{
  [SerializeField] private Rigidbody rb;
  [SerializeField] private Transform weaponHolder;
  private Vector3 _offset;

  private void Start()
  {
    _offset = transform.position - weaponHolder.position;
  }

  private void Update()
  {
    rb.position = weaponHolder.position + _offset;
    //transform.rotation = weaponHolder.rotation;
  }
}
