using UnityEngine;

public class OffsetFlashlight : MonoBehaviour
{
    [SerializeField] private Transform playerCamera; // Reference to the player's camera
    [SerializeField] private Vector3 offset = new Vector3(0.5f, -0.3f, 0.2f); // Offset from camera position

    private void Start()
    {
        // If camera reference is not set, try to find the main camera
        if (playerCamera == null)
        {
            playerCamera = Camera.main.transform;
        }
    }

    private void LateUpdate()
    {
        if (playerCamera != null)
        {
            // Update position to follow camera with offset
            transform.position = playerCamera.position + playerCamera.TransformDirection(offset);
            
            // Match the rotation of the camera
            transform.rotation = playerCamera.rotation;
        }
    }
}
