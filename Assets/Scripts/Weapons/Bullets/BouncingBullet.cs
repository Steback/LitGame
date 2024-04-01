using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBullet : Bullet
{
    [SerializeField] private float boundingImpulse = 10.0f;
    
    public override void ShotEffect(Vector3 velocity)
    {
        rigidbody.velocity = new Vector3(velocity.x, 0.0f, velocity.z);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        Vector3 direction = transform.up - rigidbody.velocity.normalized;
        rigidbody.velocity = direction * boundingImpulse;
    }
}
