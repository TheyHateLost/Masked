using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float sideSpeed = 15f;
    public float screenLimit = 8f; // How far left/right the player can go

    [Header("Tilt Settings")]
    public float maxTiltAngle = 30f; // Maximum rotation degree
    public float tiltSpeed = 150f;
    public float tiltReturnSpeed = 5f; // How fast it centers back

    private float currentTilt = 0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float steerInput = Input.GetAxis("Horizontal"); // A/D or Left/Right

        // 1. HANDLE ROTATION (The Tilt)
        if (steerInput != 0)
        {
            // Tilt based on input
            currentTilt -= steerInput * tiltSpeed * Time.deltaTime;
        }
        else
        {
            // Smoothly return to 0 when no key is pressed
            currentTilt = Mathf.Lerp(currentTilt, 0, Time.deltaTime * tiltReturnSpeed);
        }

        // CLAMP: This is where the magic happens
        currentTilt = Mathf.Clamp(currentTilt, -maxTiltAngle, maxTiltAngle);

        // Apply tilt
        transform.localRotation = Quaternion.Euler(0, 0, currentTilt);

        // 2. HANDLE POSITION (Side-to-Side)
        float horizontalMove = steerInput * sideSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position + new Vector3(horizontalMove, 0, 0);

        // Optional: Keep player within screen bounds
        newPosition.x = Mathf.Clamp(newPosition.x, -screenLimit, screenLimit);

        transform.position = newPosition;
    }
}