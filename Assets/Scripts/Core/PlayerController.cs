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
    private FollowCamera _followCamera;
    
    [SerializeField] private GameObject cameraPrefab;
    [SerializeField] private WeaponSlot weaponSlot;
    
    
    private static readonly int IsMovingHash = Animator.StringToHash("IsMoving");
    private static readonly int FiringHash = Animator.StringToHash("Firing");

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
                _followCamera = cameraInstance.GetComponent<FollowCamera>();
                if (_followCamera != null)
                {
                    _followCamera.setTarget(transform);
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
            _animator.SetBool(IsMovingHash, false);
        }
        else
        {
            _animator.SetBool(IsMovingHash, true);
        }
    }

    public void OnFire(InputValue value)
    {
        if (weaponSlot != null && weaponSlot.weapon != null)
        {
            _animator.SetTrigger(FiringHash);
        }
    }

    public void OnLook(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        _movement.Rotate(input.x);
    }

    public void SetWeapon(Weapon inWeapon)
    {
        if (weaponSlot != null)
        {
            weaponSlot.SetWeapon(inWeapon);
        }
    }

    public void Fire()
    {
        weaponSlot.weapon.Fire();
    }
}
