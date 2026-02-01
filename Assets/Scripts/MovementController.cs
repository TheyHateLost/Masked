using Unity.VisualScripting;
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

    [SerializeField] private Animator _animator;
    private float currentSpeed = 0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public bool hasPowerUp;
    private float steeringSpeed;

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

        // Steering Logic
        transform.Rotate(0, 0, -steerInput * steeringSpeed * Time.deltaTime);

        // Optional: Add some visual feedback for steering, like tilting the sprite

        // Animator logic: set "isMoving" based on currentSpeed
        // Animator logic: set "isMoving" based on currentSpeed
        if (_animator != null)
        {
            _animator.SetBool("isTurnLeft", currentSpeed > 0.01f);
        }
        if (_animator != null)
        {
            _animator.SetBool("isTurnR", currentSpeed > 0.02f);
        }

        if (rb.linearVelocity.y == 0)
        {
            _animator.SetBool("isTurnLeft", false);
            _animator.SetBool("isTurnR", false);
        }
        if (steerInput < 0)
        {
            _animator.SetBool("isTurnLeft", true);
            _animator.SetBool("isTurnR", false);
        }
        else if (steerInput > 0)
        {
            _animator.SetBool("isTurnR", true);
            _animator.SetBool("isTurnLeft", false);

        }
       

        // Optional: Keep player within screen bounds
        newPosition.x = Mathf.Clamp(newPosition.x, -screenLimit, screenLimit);

        transform.position = newPosition;
    }
}