using UnityEngine;
using TMPro;

public class Test : MonoBehaviour
{
    private bool isDoorOpen = false;

    public GameObject pickUpText;
    public GameObject noKeyText;

    private Quaternion closedRotation;
    private Quaternion openRotation;
    public float openAngle = 90f;
    public float openSpeed = 2f;
    private Transform doorPivot;
    private Transform player;
    public float interactionDistance = 3f;

    void Awake()
    {
        doorPivot = transform.parent;
        closedRotation = doorPivot.rotation;
        openRotation = Quaternion.Euler(doorPivot.eulerAngles + new Vector3(0, openAngle, 0));
    }

    void Start()
    {
        player = Camera.main.transform;
        pickUpText.SetActive(false);
        noKeyText.SetActive(false);
    }

    void OnMouseOver()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= interactionDistance)
        {
            if (!isDoorOpen)
            {
                pickUpText.SetActive(true);
                if (PlayerInventory.Instance.keys == 0)
                {
                    noKeyText.SetActive(true);
                }
            }

        }
    }

    void OnMouseExit()
    {
        pickUpText.SetActive(false);
        noKeyText.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance <= interactionDistance && PlayerInventory.Instance.keys > 0 && !isDoorOpen)
            {
                isDoorOpen = true;
                PlayerInventory.Instance.keys--;
                PlayerInventory.Instance.UpdateKeyText();
                Debug.Log("Дверь открыта! Осталось ключей: " + PlayerInventory.Instance.keys);
            }
        }

        Quaternion targetRotation = isDoorOpen ? openRotation : closedRotation;
        doorPivot.rotation = Quaternion.Lerp(doorPivot.rotation, targetRotation, Time.deltaTime * openSpeed);
    }
}