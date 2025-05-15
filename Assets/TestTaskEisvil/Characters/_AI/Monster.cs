using System;
using TestTaskEisvil._Level;
using TestTaskEisvil.Characters._AI._Components;
using UnityEngine;

namespace TestTaskEisvil.Characters._AI
{
    public class Monster : EnemyAI, IDamageReceiver
    {
        [SerializeField] private HealthController healthController;
        [SerializeField] private AIMover mover;
        [SerializeField] private AICombatController combatController;
        [SerializeField] private AIStateController stateController;
        private MonsterData _data;
        private bool _isInited;

        public IAiTarget Target { get; set; }
        public float AttackDistance => _data.AttackDistance;

        public void Init(MonsterData data, Level level)
        {
            _data = data;
            stateController.Init(new AiStateControllerData
            {
                Mover = mover,
                Pawn = this,
                Level = level,
                CombatController = combatController,
                HealthController = healthController
            });
            combatController.Init(_data.Damage, _data.AttackCooldown, _data.AttackDistance);
            _isInited = true;
        }

        public void OnSpawn()
        {
            healthController.Init(_data.MaxHealth);
        }


        public void ReceiveDamage(int damage)
        {
            healthController.ReceiveDamage(damage);
        }

        public void MoveTo(Vector3 bodyPosition)
        {
            mover.MoveTo(bodyPosition, _data.MoveSpeed);
        }

        public void StopMove()
        {
            mover.StopMove();
        }

        private void Update()
        {
            if (_isInited)
            {
                stateController.UpdateState();
            }
        }
    }

    [Serializable]
    public struct MonsterData
    {
        public int MaxHealth;
        public float MoveSpeed;
        public int Damage;
        public float AttackCooldown;
        public float AttackDistance;
    }
}