using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Transform cameraPosition;
    [SerializeField] private Vector3 _cameraOffset;
    void Start()
    {
        cameraPosition = GetComponent<Transform>();

    }
    void Update()
    {
        //cameraTransform.position = _player.transform.position + _cameraOffset;
        cameraPosition.position = _player.transform.position + _cameraOffset;
        

    }
}
