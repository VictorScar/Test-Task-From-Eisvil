using System;
using UnityEngine;

namespace TestTaskEisvil.Characters._AI._Components
{
    public class AICombatController : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        private int _damage;
        private float _attackColldown;
        private float _attackDistance;
        private float _cooldown;
        private IDamageSource _damageSource;

        public event Action onAttack; 

        public void Init(AiCombatControllerData data)
        {
            _damage = data.Damage;
            _attackDistance = data.AttackDistance;
            _attackColldown = data.AttackCooldown;
            _damageSource = data.DamageSource;
        }

        public void Attack()
        {
            if (_cooldown <= 0)
            {
                if (Physics.Raycast(transform.position, transform.forward, out var hit, _attackDistance, layerMask))
                {
                    if (hit.collider.TryGetComponent<IDamageReceiver>(out var enemy))
                    {
                        enemy.ReceiveDamage(_damage, _damageSource);
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

    public struct AiCombatControllerData
    {
        public IDamageSource DamageSource;
        public int Damage;
        public float AttackCooldown;
        public float AttackDistance;
    }
}