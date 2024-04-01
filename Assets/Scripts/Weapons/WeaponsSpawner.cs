using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsSpawner : MonoBehaviour
{
    private Weapon _weapon;
    
    [SerializeField] private GameObject prefab;
    
    void Start()
    {
        if (prefab != null)
        {
            Transform transform = GetComponent<Transform>();
            GameObject gameObject = Instantiate(prefab, transform.position, transform.rotation);
            if (gameObject != null)
            {
                gameObject.transform.SetParent(transform);
                
                Weapon weapon = gameObject.GetComponent<Weapon>();
                if (weapon != null)
                {
                    _weapon = weapon;
                    _weapon.onEquipped += OnWeaponEquipped;
                    _weapon.onUnequipped += OnWeaponUnequipped;
                }
            }
        }
    }

    public void OnWeaponEquipped()
    {
        
    }

    public void OnWeaponUnequipped()
    {
        if (_weapon != null)
        {
            Transform weaponTransform = _weapon.transform;
            weaponTransform.SetParent(transform);
            weaponTransform.localPosition = Vector3.zero;
            weaponTransform.localRotation = Quaternion.identity;
        } 
    }
}
