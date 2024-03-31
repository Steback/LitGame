using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    [SerializeField] private float speed = 100.0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 Direction)
    {
        _rigidbody.velocity = Direction * speed;
    }
}
