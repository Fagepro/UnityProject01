using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerController _player;
    private int _damage;

    private void DamagePlayer(int damage)
    {
        //SetEnemyDamage();
        _player.TakeEnemyDamage(damage);
    }
}
