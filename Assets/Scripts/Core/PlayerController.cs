using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : PlayerInput
{
    public FollowCamera followCamera;
    
    [SerializeField] private GameObject cameraPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        if (cameraPrefab != null)
        {
            Transform transform = GetComponent<Transform>();
            GameObject cameraInstance = Instantiate(cameraPrefab, transform.position, transform.rotation);
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
}
