using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool isEquiped = false;
    
    [SerializeField] private RuntimeAnimatorController runtimeAnimatorController;
    
    public delegate void OnEquipped();
    public OnEquipped onEquipped;
    
    public delegate void OnUnequipped();
    public OnUnequipped onUnequipped;
    
    
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
}
