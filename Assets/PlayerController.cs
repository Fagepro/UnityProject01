using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera playerCamera;
    [SerializeField] private float _playerSpeed = 1;
    [SerializeField] private float _playerJumpForce = 1;
    private Rigidbody rb;
    private bool isOnPlatform = false;



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
            float hDirection = Input.GetAxis("Horizontal");
            MovePlayer(hDirection);
            Debug.Log("Player is Moving");
        }
        else
        {
            MovePlayer(0);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Platform")
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
        float dir = direction;
        if (dir == -1)
        { 
            rb.AddForce(new Vector3(-1 * _playerSpeed, 0, 0), ForceMode.Impulse);
        }

        if (dir == 1)
        {
            rb.AddForce(new Vector3(1 * _playerSpeed, 0, 0), ForceMode.Impulse);
        }
    }
}
