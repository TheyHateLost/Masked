using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float acceleration = 5f;
    public float steeringSpeed = 200f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Get Input
        float moveInput = Input.GetAxis("Vertical");
        float steerInput = Input.GetAxis("Horizontal");

        // Forward Movement: Apply force or move position relative to car's rotation
        rb.linearVelocity = transform.up * moveInput * acceleration;

        // Steering: Rotate the car based on horizontal input
        if (moveInput != 0)
        { // Only steer if moving
            float rotationAmount = -steerInput * steeringSpeed * Time.fixedDeltaTime;
            rb.MoveRotation(rb.rotation + rotationAmount);
        }
    }
}