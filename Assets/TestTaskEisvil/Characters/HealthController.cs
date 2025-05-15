using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private int _maxHealth;
    private int _currntHealth;
    private bool _isDead;

    public event Action<int> onHealthChanged;
    public event Action onDie;
    public int CurrentHealth => _currntHealth;

    public bool IsDead => _isDead;
    
    public void Init(int maxHealth)
    {
        _maxHealth = maxHealth;
        _currntHealth = maxHealth;
        _isDead = false;
    }

    public void ReceiveDamage(int damage)
    {
        if (!_isDead)
        {
            if (damage <= _currntHealth)
            {
                _currntHealth -= damage;
                onHealthChanged?.Invoke(_currntHealth);
            }
            else
            {
                _currntHealth = 0;
                onDie?.Invoke();
            }
        }
       
    }
}
