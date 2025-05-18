using System;
using Cysharp.Threading.Tasks;
using TestTaskEisvil.Characters._AI._Components;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TestTaskEisvil.Characters._AI
{
    public class Nest : EnemyAI, IDamageReceiver
    {
        [SerializeField] private HealthController healthController;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private Animator animator;
        
        private NestData _data;

        private void OnDestroy()
        {
            healthController.onDie -= Die;
        }

        public void Init(NestData data)
        {
            _data = data;
            OnSpawn();
        }
        
        public Transform GetSpawnPoint()
        {
            if (spawnPoints != null)
            {
                var spawnPointNumber = Random.Range(0, spawnPoints.Length);
                return spawnPoints[spawnPointNumber];
            }

            return null;
        }

        public override void OnSpawn()
        {
            healthController.Init(_data.MaxHealth);
            healthController.onDie += Die;
            animator.SetBool("IsDead", false);
        }

        public override void Reset()
        {
            OnSpawn();
        }

        protected override void OnDie()
        {
            animator.SetBool("IsDead", true);
            DeathDelay();
        }

        private async UniTask DeathDelay()
        {
            await UniTask.WaitForSeconds(_data.DespawnTime);
            Despawn();
            Destroy(gameObject);
        }

        public void ReceiveDamage(int damage, IDamageSource source)
        {
           healthController.ReceiveDamage(damage);
        }
    }

    [Serializable]
    public struct NestData
    {
        public float DespawnTime;
        public int MaxHealth;
    }
}