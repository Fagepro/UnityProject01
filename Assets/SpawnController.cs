using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject trapPrefab;
    [SerializeField] private GameObject enemyPrefab;
    private Enemy _enemy;
    private void Start()
    {
        
    }

    public void SpawnByType(ObjectTypes objectType, Vector3 prefabPos)
    {
        switch  (objectType)
        {
            case ObjectTypes.Enemy:
            {
                SpawnEnemyPrefab(enemyPrefab, prefabPos);
                break;
            }
            case ObjectTypes.Trap:
            {
                SpawnEnemyPrefab(trapPrefab, prefabPos);
                break;
            } 
        }
    }

    private void SpawnEnemyPrefab(GameObject prefab, Vector3 prefabPos)
    {
        GameObject instantiatedEnemy = Instantiate(prefab, prefabPos, Quaternion.identity);
        _enemy = instantiatedEnemy.GetComponent<Enemy>(); 
    }

}


