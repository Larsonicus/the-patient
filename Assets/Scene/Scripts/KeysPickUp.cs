using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysPickUp : MonoBehaviour
{
    private bool inReach;
    public GameObject pickUpText;
    public AudioSource pickUpSound;

    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Reach"))
        {
            inReach = true;
            pickUpText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Reach"))
        {
            inReach = false;
            pickUpText.SetActive(false);
        }
    }



    void Update()
    {
        if (Input.GetButtonDown("Interact") && inReach)
        {
            pickUpSound.Play();
            PlayerInventory.Instance.AddKey();
            inReach = false;
            pickUpText.SetActive(false);
            Destroy(gameObject); 
        }
    }
}