using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float resetTimer = 0.0f;
    public Rigidbody rigidbody;
    public Collider Collider;

    [SerializeField] private float timeToReset = 10.0f;
    [SerializeField] private Vector3 sleepPosition = new Vector3(0.0f, -100.0f, 0.0f);
    

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        Collider = GetComponent<Collider>();
        Reset();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        resetTimer -= Time.deltaTime;
        if (resetTimer < 0)
        {
            Reset();
        }
    }

    public void Shot(Vector3 velocity)
    {
        rigidbody.isKinematic = false;
        Collider.enabled = true;
        ShotEffect(velocity);
        resetTimer = timeToReset;
    }

    public virtual void ShotEffect(Vector3 velocity)
    {
        rigidbody.velocity = velocity;
    }

    public void Reset()
    {
        transform.position = sleepPosition;
        if (rigidbody)
        {
            rigidbody.isKinematic = true;
            Collider.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Reset();
    }
}
