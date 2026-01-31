using UnityEngine;

public class TrackScroller : MonoBehaviour
{
    public float speed = 0.5f; // Adjust speed in the Inspector
    private Renderer rend;
    private Vector2 offset;

    void Start()
    {
        rend = GetComponent<Renderer>(); // Get the Renderer component
        offset = rend.material.mainTextureOffset; // Get the initial offset
    }

    void Update()
    {
        // Calculate the new offset based on time and speed
        // The Y value is typically used for vertical scrolling in 2D
        offset.y += Time.deltaTime * speed;

        // Apply the new offset to the material's main texture
        rend.material.mainTextureOffset = offset;
    }
}
