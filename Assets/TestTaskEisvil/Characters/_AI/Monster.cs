using System;
using Cysharp.Threading.Tasks;
using TestTaskEisvil._Level;
using TestTaskEisvil.Characters._AI._Components;
using TestTaskEisvil.Characters._AI._Components.States;
using TestTaskEisvil.Pooling;
using UnityEngine;

namespace TestTaskEisvil.Characters._AI
{
    public class Monster : EnemyAI, IDamageReceiver, IDamageSource
    {
        [SerializeField] private HealthController healthController;
        [SerializeField] private AIMover mover;
        [SerializeField] private AICombatController combatController;
        [SerializeField] private AIStateController stateController;
        [SerializeField] private AIAnimationController animationController;
        [SerializeField] private Collider collider;
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
                HealthController = healthController,
                AnimationController = animationController,
                Collider = collider
            });
            combatController.Init(new AiCombatControllerData
            {
                DamageSource = this,
                Damage = _data.Damage,
                AttackDistance = _data.AttackDistance,
                AttackCooldown = _data.AttackCooldown
            });
           // healthController.Init(_data.MaxHealth);
            
            _isInited = true;
        }

        public void OnSpawn()
        {
            healthController.Init(_data.MaxHealth);
            stateController.Run();
        }

        protected override void OnDie()
        {
            DeathDelay();
        }

        private async UniTask DeathDelay()
        {
            await UniTask.WaitForSeconds(_data.DespawnTime);
            Despawn();
        }

        public void ReceiveDamage(int damage, IDamageSource source)
        {
            healthController.ReceiveDamage(damage);
        }

        public void MoveTo(Vector3 target)
        {
            mover.MoveTo(target, _data.MoveSpeed);
            LookAt(target);
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

        public void LookAt(Vector3 target)
        {
            mover.LookAt(target, _data.RotationSpeed);
        }
        
        public override void Reset()
        {
            OnSpawn();
        }
    }

    [Serializable]
    public struct MonsterData
    {
        public int MaxHealth;
        public float MoveSpeed;
        public float RotationSpeed;
        public int Damage;
        public float AttackCooldown;
        public float AttackDistance;
        public float DespawnTime;
    }
}