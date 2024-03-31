using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput), typeof(Movement))]
public class PlayerController : MonoBehaviour
{
    private Transform _transform;
    private Movement _movement;
    private Vector2 _movementInput;
    
    public FollowCamera followCamera;
    
    [SerializeField] private GameObject cameraPrefab;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _movement = GetComponent<Movement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (cameraPrefab != null)
        {
            GameObject cameraInstance = Instantiate(cameraPrefab, _transform.position, _transform.rotation);
            if (cameraInstance != null)
            {
                followCamera = cameraInstance.GetComponent<FollowCamera>();
                if (followCamera != null)
                {
                    followCamera.setTarget(transform);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        _movement.Move(new Vector3(_movementInput.x, 0.0f, _movementInput.y));
    }

    public void OnMove(InputValue value)
    { 
        _movementInput = value.Get<Vector2>();
    }

    public void OnShot(InputValue value)
    {
        Debug.Log("OnShot");
    }
}
