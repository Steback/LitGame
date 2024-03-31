using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    private Weapon _weapon;

    [SerializeField] private Vector3 offsetPosition;
    [SerializeField] private Vector3 offsetRotation;
    
    public void SetWeapon(Weapon inWeapon)
    {
        if (inWeapon != null)
        {
            _weapon = inWeapon;

            Transform weaponTransform = _weapon.GetComponent<Transform>();
            weaponTransform.SetParent(transform);
            weaponTransform.localPosition = offsetPosition;
            
            Quaternion rotation = Quaternion.identity;
            rotation.eulerAngles = offsetRotation;
            
            weaponTransform.localRotation = rotation;
        }
    }
}
