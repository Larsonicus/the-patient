using UnityEngine;

public class OffsetFlashlight : MonoBehaviour
{
    [SerializeField] private Transform playerCamera; 
    [SerializeField] private Vector3 offset = new Vector3(0.5f, -0.3f, 0.2f); 

    private void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main.transform;
        }
    }

    private void LateUpdate()
    {
        if (playerCamera != null)
        {
            transform.position = playerCamera.position + playerCamera.TransformDirection(offset);
            
            transform.rotation = playerCamera.rotation;
        }
    }
}
