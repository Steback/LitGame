using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform target;

    [SerializeField] private Vector3 offset;
    
    public void setTarget(Transform inTarget)
    {
        if (inTarget != null)
        {
            target = inTarget;

            Transform transform = GetComponent<Transform>();
            transform.SetParent(target);
            transform.localPosition = offset;
        }
    }
}
