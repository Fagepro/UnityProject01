using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    private Transform coinTransform;
    private Vector3 coinPosition;
    void Start()
    {
        coinPosition = GetComponent<Transform>().position;
        Instantiate(coinPrefab);
        coinPrefab.transform.position = coinPosition;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
