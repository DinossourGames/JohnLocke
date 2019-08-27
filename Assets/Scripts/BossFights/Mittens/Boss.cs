using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Boss : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _totalHealth;

    public int Health
    {
        get => _health;
        set => _health = value;
    }

    public int TotalHealth
    {
        get => _totalHealth;
        set => _totalHealth = value;
    }


    private void Start()
    {
        Health = TotalHealth;
    }

    private void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        _health -= damageAmount;
    }
}
