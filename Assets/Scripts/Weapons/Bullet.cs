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
    }

    private void Start()
    {
        transform.position = sleepPosition;
        rigidbody.isKinematic = true;
        Collider.enabled = false;
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
        rigidbody.velocity = velocity;
        resetTimer = timeToReset;
    }

    public void Reset()
    {
        transform.position = sleepPosition;
        rigidbody.isKinematic = true;
        Collider.enabled = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        Reset();
    }
}
