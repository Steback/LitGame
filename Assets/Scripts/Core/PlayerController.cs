using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput), typeof(Movement), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    private Transform _transform;
    private Movement _movement;
    private Vector2 _movementInput;
    private Animator _animator;
    [SerializeField] private GameObject cameraPrefab;
    
    public FollowCamera followCamera;
    
    private static readonly int SpeedHash = Animator.StringToHash("Speed");

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _movement = GetComponent<Movement>();
        _animator = GetComponent<Animator>();
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

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        _movement.Move(new Vector3(_movementInput.x, 0.0f, _movementInput.y));
    }

    public void OnMove(InputValue value)
    { 
        _movementInput = value.Get<Vector2>();
        if (_movementInput == Vector2.zero)
        {
            _animator.SetFloat(SpeedHash, 0.0f);
        }
        else
        {
            _animator.SetFloat(SpeedHash, Math.Min(_movementInput.magnitude, 1.0f));
        }
    }

    public void OnFire(InputValue value)
    {
        Debug.Log("OnShot");
    }

    public void OnLook(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        _movement.Rotate(input.x);
    }
}
