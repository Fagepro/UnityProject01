using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyTypes enemyType;
    [SerializeField] private int enemyDamage;

    private void Start()
    {
        SpawnEnemy(enemyType);
    }

    private void SpawnEnemy(EnemyTypes enemy)
    {

    }
}


