using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool isEquiped = false;

    [SerializeField] private RuntimeAnimatorController runtimeAnimatorController;
    
    private void OnCollisionEnter(Collision other)
    {
        PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.SetWeapon(this);
            playerController.GetComponent<Animator>().runtimeAnimatorController = runtimeAnimatorController;
        }
    }
}
