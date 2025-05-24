using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Test : MonoBehaviour
{
    [SerializeField] private int keys = 0; // Счетчик ключей
    public TMP_Text keyText; // Текстовое поле для отображения количества ключей

    private bool isDoorOpen = false; // Состояние двери (открыта/закрыта)

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
        UpdateKeyText();
        pickUpText.SetActive(false);
        noKeyText.SetActive(false);
    }

    // Метод для увеличения счетчика ключей
    public void AddKey()
    {
        keys++;
        UpdateKeyText();
    }

    void OnMouseOver()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= interactionDistance)
        {
            pickUpText.SetActive(true);
            if(keys == 0)
            {
                noKeyText.SetActive(true);
            }
        }

    }

    private void OnMouseExit()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= interactionDistance)
        {
            pickUpText.SetActive(false);
            noKeyText.SetActive(false);
        }
    }

    void Update()
    {
        // Проверяем нажатие мыши (например, левая кнопка)
        if (Input.GetButtonDown("Interact") )
        {
            
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance <= interactionDistance && keys > 0 && !isDoorOpen)
            {
                // Открываем дверь и тратим ключ
                isDoorOpen = true;
                keys--;
                UpdateKeyText();
                Debug.Log("Дверь открыта! Осталось ключей: " + keys);
            }
        }

        // Вращаем дверь, если она открыта
        Quaternion targetRotation = isDoorOpen ? openRotation : closedRotation;
        doorPivot.rotation = Quaternion.Lerp(doorPivot.rotation, targetRotation, Time.deltaTime * openSpeed);
    }

    // Метод для обновления текстового поля
    private void UpdateKeyText()
    {
        if (keyText != null)
        {
            keyText.text = keys.ToString();
        }
    }
}