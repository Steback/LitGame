using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    public Weapon weapon;

    [SerializeField] private Vector3 offsetPosition;
    [SerializeField] private Vector3 offsetRotation;
    
    public void SetWeapon(Weapon inWeapon)
    {
        if (inWeapon != null)
        {
            Debug.Log(offsetPosition);
            Debug.Log(offsetRotation);
            if (weapon != null)
            {
                weapon.SetEquipped(false);
                weapon = null;
            }
            
            weapon = inWeapon;
            weapon.SetEquipped(true);

            Transform weaponTransform = weapon.GetComponent<Transform>();
            weaponTransform.SetParent(transform);
            weaponTransform.localPosition = offsetPosition;
            
            Quaternion rotation = Quaternion.identity;
            rotation.eulerAngles = offsetRotation;
            
            weaponTransform.localRotation = rotation;
        }
    }
}
