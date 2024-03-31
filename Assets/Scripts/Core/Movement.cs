using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private Transform _transform;
    
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float rotationSpeed = 10.0f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    public void Move(Vector3 direction)
    {
        Vector3 forward = _transform.forward * direction.z;
        Vector3 right = _transform.right * direction.x;
        _rigidBody.velocity = (forward + right) * (speed * Time.fixedDeltaTime);
    }

    public void Rotate(float value)
    {
        Vector3 angles = _rigidBody.rotation.eulerAngles;
        angles.y += value * (rotationSpeed * Time.fixedDeltaTime);

        Quaternion rotation = Quaternion.identity;
        rotation.eulerAngles = angles;
        
        _rigidBody.rotation = rotation;
    }
}
