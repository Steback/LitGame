using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractionBullet : Bullet
{
    [SerializeField] private float pullRadius = 8;
    [SerializeField] private float maxSeparation = 2;
    [SerializeField] private float pullForce = 10;
    [SerializeField] private LayerMask interactableMask; //layermask of objects that can react to the attraction force
    

    private void FixedUpdate()
    {
        foreach (Collider collider in Physics.OverlapSphere(transform.position, pullRadius, interactableMask))
        {
            Rigidbody colliderRigidbody = collider.GetComponent<Rigidbody>();
            if (colliderRigidbody == null)
            {
                continue;
            }
            
            Vector3 forceDirection = transform.position - colliderRigidbody.position;
            float distance = forceDirection.magnitude;
            forceDirection = forceDirection.normalized;
            if (distance < maxSeparation)
            {
                continue;
            }
            
            float forceRate = pullForce / distance;
            colliderRigidbody.AddForce(forceDirection * (forceRate / colliderRigidbody.mass));
        }
    }

    public override void ShotEffect(Vector3 velocity)
    {
        rigidbody.velocity = new Vector3(velocity.x, 0.0f, velocity.z);
    }
}
