using UnityEngine;

public class InfiniteRoad : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // This shifts the texture over time
        Vector2 offset = spriteRenderer.material.mainTextureOffset;
        offset.y += scrollSpeed * Time.deltaTime;
        spriteRenderer.material.mainTextureOffset = offset;
    }
}