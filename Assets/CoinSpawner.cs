using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private Vector3 coinPos;
    void Start()
    {
        
    }

    public void Inject(bool isDead, Vector3 coinPrefabPosition, GameObject coinPrefab)
    {
        
        if (isDead == true)
        {
            coinPrefab.gameObject.SetActive(true);
            coinPos = coinPrefab.GetComponent<Transform>().position;
            coinPrefabPosition = coinPos;
            Debug.Log("Coins was spawned/activated");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
