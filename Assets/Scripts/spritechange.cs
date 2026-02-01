using UnityEngine;

public class spritechange : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite normalSprite;    // The default look
    public Sprite nearSprite;      // What it changes into

    [Header("Settings")]
    public Transform playerTransform;
    public float activationDistance = 20f;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Automatically find the player by tag if not assigned
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        // Calculate distance between this object and the player
        float distance = Vector2.Distance(transform.position, playerTransform.position);

        if (distance <= activationDistance)
        {
            spriteRenderer.sprite = nearSprite;
        }
        else
        {
            spriteRenderer.sprite = normalSprite;
        }
    }
}