using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWinScreen : MonoBehaviour
{
    private Transform player;
    public float interactionDistance = 3f;
    private bool isDoorOpen = false;
    public GameObject pickUpText;
    public GameObject winMenu;
    public SFPSC_FPSCamera camera;

    void Start()
    {
        player = Camera.main.transform;
        pickUpText.SetActive(false);
    }


    void OnMouseOver()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= interactionDistance)
        {
            if (!isDoorOpen)
            {
                pickUpText.SetActive(true);

            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (winMenu != null)
                {
                    winMenu.SetActive(true); 
                    Time.timeScale = 0f;     
                    Cursor.lockState = CursorLockMode.None; 
                    Cursor.visible = true;
                    camera.LockCamera();
                }
            }

        }
    }

    void OnMouseExit()
    {
        pickUpText.SetActive(false);
    }
}
