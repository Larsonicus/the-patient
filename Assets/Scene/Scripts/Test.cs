using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;
    public float openAngle = 90f; // угол открытия
    public float openSpeed = 2f; // скорость открытия
    private Transform doorPivot; // ссылка на родительский объект (пустышку)
    private float openTimer = 0f;
    public float openDuration = 5f; // время, на которое дверь остается открытой
    public float interactionDistance = 3f; // максимальное расстояние для взаимодействия
    private Transform player; // ссылка на игрока

    // Start is called before the first frame update
    void Awake()
    {
        doorPivot = transform.parent; // получаем родительский объект
        closedRotation = doorPivot.rotation;
        openRotation = Quaternion.Euler(doorPivot.eulerAngles + new Vector3(0, openAngle, 0));
    }

    void Start()
    {
        player = Camera.main.transform; // получаем ссылку на игрока (камеру)
    }

    void OnMouseOver()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= interactionDistance)
        {
            isOpen = true;
            openTimer = openDuration; // сбрасываем таймер при наведении
        }
    }

    void OnMouseExit()
    {
        // Не закрываем дверь сразу, ждем таймер
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            openTimer -= Time.deltaTime;
            if (openTimer <= 0)
            {
                isOpen = false;
            }
        }

        Quaternion targetRotation = isOpen ? openRotation : closedRotation;
        doorPivot.rotation = Quaternion.Lerp(doorPivot.rotation, targetRotation, Time.deltaTime * openSpeed);
    }
}
