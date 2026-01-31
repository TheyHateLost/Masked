using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target; // Drag your player/vehicle GameObject here in the Inspector
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Adjust the offset as needed
    public float smoothSpeed = 0.125f; // Controls how smoothly the camera follows

    // LateUpdate is called after all Update functions have been called, 
    // ensuring the player has moved for the current frame
    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position of the camera
            Vector3 desiredPosition = target.position + offset;

            // Smoothly move the camera towards the desired position (lerping)
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime * 60);
            // Multiplying by 60 for consistency with fixed framerate in LateUpdate

            transform.position = smoothedPosition;

            // Optional: make the camera look at the target (useful in 3D but sometimes in 2.5D)
            // transform.LookAt(target); 
        }
    }
}
