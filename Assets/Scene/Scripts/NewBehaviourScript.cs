using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] private int _speed = 1;
    [SerializeField] private float _rotateSpeed;

    private float _timer;
    void Start()
    {
        Debug.Log("Start");
    }

    void Update()
    {

        _timer += Time.deltaTime;

        if (_timer >= 2.0f)
        {
            transform.Translate(0, 0, _speed * Time.deltaTime);
            transform.Rotate(0, _rotateSpeed * Time.deltaTime, 0 );
        }
       
    }
}
