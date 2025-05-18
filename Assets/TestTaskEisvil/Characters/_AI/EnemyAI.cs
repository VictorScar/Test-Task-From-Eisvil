using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using TestTaskEisvil.Pooling;
using UnityEngine;

namespace TestTaskEisvil.Characters._AI
{
    public abstract class EnemyAI : MonoBehaviour, IPoolObject
    {
        [SerializeField] protected EnemyID id;
        [SerializeField] private float despawnTime = 3f;
        public event Action<IPoolObject> onSpawn;
        public event Action<IPoolObject> onDeSpawn;
        public event Action<EnemyAI> onDie;

        public EnemyID ID => id;


        public abstract void Reset();

        public void Die()
        {
            onDie?.Invoke(this);
           OnDie();
           OnDespawnAsync(CancellationToken.None);
        }

        protected virtual void OnDie()
        {
        }

        public void SetActive(bool enabled)
        {
            gameObject.SetActive(enabled);
        }

        private async UniTask OnDespawnAsync(CancellationToken cancellationToken)
        {
            await UniTask.WaitForSeconds(despawnTime);
            onDeSpawn?.Invoke(this);
        }
    }

    public enum EnemyID
    {
        Nest,
        Gobolt,
        Worm
    }
}