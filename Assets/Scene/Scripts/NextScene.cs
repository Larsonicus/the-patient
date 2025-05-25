using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private Transform player;
    public float interactionDistance = 3f;
    private bool isDoorOpen = false;
    public GameObject pickUpText;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

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
                LoadScene("Level2");
            }

        }
    }

    void OnMouseExit()
    {
        pickUpText.SetActive(false);
    }
}
