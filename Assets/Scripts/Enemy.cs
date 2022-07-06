using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerController _player;
    [SerializeField] private int toPlayerDamage;
    [SerializeField] private bool isMovable;

    public int GetDamage()
    {
        return toPlayerDamage;
    }
}
