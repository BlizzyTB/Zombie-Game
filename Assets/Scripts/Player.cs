using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float _moveSpeed = 10f;
    Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rb.velocity = Vector3.forward * (_moveSpeed * Time.deltaTime);
            Debug.Log("Moving Forward");
        }
        if (Input.GetKey(KeyCode.A))
        {
            _rb.velocity = Vector3.left * (_moveSpeed * Time.deltaTime);
            Debug.Log("Moving Left");
        }
        if (Input.GetKey(KeyCode.S))
        {
            _rb.velocity = Vector3.back * (_moveSpeed * Time.deltaTime);
            Debug.Log("Moving Backwards");
        }
        if (Input.GetKey(KeyCode.D))
        {
            _rb.velocity = Vector3.right * (_moveSpeed * Time.deltaTime);
            Debug.Log("Moving Right");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jumping");
        }
    }
}
