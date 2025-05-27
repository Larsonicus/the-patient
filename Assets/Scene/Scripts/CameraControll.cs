using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    [SerializeField] private float zSpeed = 1.0f;
    

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, 0, zSpeed * Time.deltaTime);
    }
}
