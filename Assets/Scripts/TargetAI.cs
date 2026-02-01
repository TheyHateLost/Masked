using UnityEngine;

public class TargetAI : MonoBehaviour
{
    [Header("Movement")]
    public float maxSpeed = 5f;
    public float detectionRange = 5f;
    public float sightRange = 10f;

    [Header("Timer Reward")]
    public float timeBonus = 5f; // How much time to add on hit
    public float hitCooldown = 1f; // Prevents adding time too fast

    private Rigidbody2D rb;
    private GameObject target;
    private bool seePlayer;
    private float lastHitTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        HandleAI();
    }

    void HandleAI()
    {
        if (!seePlayer)
        {
            Collider2D foundPlayer = Physics2D.OverlapCircle(transform.position, detectionRange, LayerMask.GetMask("Default")); // Ensure player is on Default layer
            if (foundPlayer != null && foundPlayer.CompareTag("Player"))
            {
                target = foundPlayer.gameObject;
                seePlayer = true;
            }
        }
        else
        {
            Vector2 direction = (target.transform.position - transform.position).normalized;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, sightRange);

            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                rb.linearVelocity = direction * maxSpeed;

                // Rotate to face player
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                rb.MoveRotation(angle - 90f);
            }
            else
            {
                seePlayer = false;
                rb.linearVelocity = Vector2.zero;
            }
        }
    }

    // This runs when the player collides with the enemy
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Time.time > lastHitTime + hitCooldown)
            {
                // Find Timer and add time
                TimerController timer = Object.FindFirstObjectByType<TimerController>();
                if (timer != null)
                {
                    timer.AddTime(timeBonus);
                    Debug.Log("Time Added! +" + timeBonus);
                }

                lastHitTime = Time.time;

                // Optional: Destroy enemy after hit
                // Destroy(gameObject); 
            }
        }
    }
}
