using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICombatController : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private int _damage;
    private float _attackColldown;
    private float _attackDistance;
    private float _cooldown;

    public event Action onAttack; 

    public void Init(int damage, float attackCooldown, float attackDistance)
    {
        _damage = damage;
        _attackDistance = attackDistance;
        _attackColldown = attackCooldown;
    }

    public void Attack()
    {
        if (_cooldown <= 0)
        {
            if (Physics.Raycast(transform.position, transform.forward, out var hit, _attackDistance, layerMask))
            {
                if (hit.collider.TryGetComponent<IDamageReceiver>(out var enemy))
                {
                    enemy.ReceiveDamage(_damage);
                    onAttack?.Invoke();
                    _cooldown = _attackColldown;
                    Debug.Log("NPC Attack!");
                }
            }
        }
    }

    private void Update()
    {
        if (_cooldown > 0)
        {
            _cooldown -= Time.deltaTime;
        }
    }
}