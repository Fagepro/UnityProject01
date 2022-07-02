using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypesController : MonoBehaviour
{
    [SerializeField] private Enemy enemyDamage;
    private EnemyTypes _enemyType;
    private GameObject _enemyPrefab;
    
    void Start()
    {
        _enemyPrefab = this.gameObject;

    }
    
    void Update()
    {
        
    }
}
