using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    public delegate void OnPlayerSpawn(GameObject gameObject);

    public event OnPlayerSpawn onPlayerSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        if (prefab != null)
        {
            Transform transform = GetComponent<Transform>();
            GameObject player = Instantiate(prefab, transform.position, transform.rotation);
            if (player != null)
            {
                if (onPlayerSpawn != null)
                {
                    onPlayerSpawn.Invoke(player);
                }
            }
        }
    }
}
