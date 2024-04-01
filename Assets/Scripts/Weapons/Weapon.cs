using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool isEquiped = false;
    private int _currenPoolIndex = 0;
    
    [SerializeField] private Bullet[] _bullets;
    [SerializeField] private RuntimeAnimatorController runtimeAnimatorController;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private float shotOffset = 10.0f;
    [SerializeField] private float shotForce = 100.0f;
    
    public delegate void OnEquipped();
    public OnEquipped onEquipped;
    
    public delegate void OnUnequipped();
    public OnUnequipped onUnequipped;

    private void Start()
    {
        if (bulletPrefab != null)
        {
            GameObject demo = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
            if (demo.GetComponent<Bullet>() == null)
            {
                Destroy(demo);
                return;
            }

            _currenPoolIndex = 0;
            _bullets = new Bullet[poolSize];
            _bullets[0] = demo.GetComponent<Bullet>();
            
            for (int i = 1; i < poolSize; ++i)
            {
                GameObject bullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
                _bullets[i] = bullet.GetComponent<Bullet>();
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.SetWeapon(this);
            playerController.GetComponent<Animator>().runtimeAnimatorController = runtimeAnimatorController;
        }
    }

    public void SetEquipped(bool inIsEquipped)
    {
        isEquiped = inIsEquipped;
        if (isEquiped && onEquipped != null)
        {
            onEquipped.Invoke();
        }
        else if (onUnequipped != null)
        {
            onUnequipped.Invoke();
        }
    }

    public void Fire()
    {
        if (_bullets.Length > 0)
        {
            _bullets[_currenPoolIndex].transform.position = transform.position + transform.forward * shotOffset;
            FireEffect(_bullets[_currenPoolIndex]);
            _currenPoolIndex++;
            if (_currenPoolIndex >= poolSize)
            {
                _currenPoolIndex = 0;
            }
        }
    }

    public virtual void FireEffect(Bullet bullet)
    {
        bullet.Shot(transform.forward * shotForce);
    }
}
