using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float acceleration = 10f;
    public float brakingForce = 25f; // Braking is usually faster than accelerating
    public float maxSpeed = 20f;
    public float coastingFriction = 1.5f; // How fast you slow down when not pressing anything
    public float steeringSpeed = 180f;

    private float currentSpeed = 0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public bool hasPowerUp;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            // You can add more logic here for power-up effects
        }
    }


    void Update()
    {
        // 1. Acceleration (W)
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        // 2. Braking (S) - Only works if moving
        else if (Input.GetKey(KeyCode.S) && currentSpeed > 0)
        {
            currentSpeed -= brakingForce * Time.deltaTime;
        }
        // 3. Natural Coasting
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, coastingFriction * Time.deltaTime);
        }

        // CLAMP: Min is 0 so no reversing, Max is your top speed
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

        // Steering Logic
        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, -steerInput * steeringSpeed * Time.deltaTime);
    }


    void FixedUpdate()
    {
        // Move forward relative to current rotation
        rb.linearVelocity = transform.up * currentSpeed;
    }
}