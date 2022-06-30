using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 1;
    [SerializeField] private float _playerJumpForce = 1;
    private Rigidbody rb;
    private bool isOnPlatform = false;
    private float _horizontalDirection;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnPlatform)
        {
            Jump();
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            _horizontalDirection = Input.GetAxis("Horizontal");
        }
    }

    private void FixedUpdate()
    {
        MovePlayer(_horizontalDirection);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Platform"))
        {
            isOnPlatform = true;
        }
    }

    private void Jump()
    {
        rb.AddForce(new Vector3(0, 1 * _playerJumpForce, 0), ForceMode.Impulse);
        isOnPlatform = false;
    }

    private void MovePlayer(float direction)
    {
        rb.MovePosition(transform.position + new Vector3(direction * _playerSpeed, 0, 0));
    }
}
