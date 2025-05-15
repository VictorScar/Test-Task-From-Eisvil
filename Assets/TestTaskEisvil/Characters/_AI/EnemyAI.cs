using System;
using UnityEngine;

namespace TestTaskEisvil.Characters._AI
{
    public abstract class EnemyAI : MonoBehaviour
    {
        [SerializeField] protected EnemyID id;
   
        public event Action<EnemyAI> onDie;

        public void Die()
        {
            onDie?.Invoke(this);
            OnDie();
        }

        protected virtual void OnDie()
        {
           
        }

        public EnemyID ID => id;

    }

    public enum EnemyID
    {
        Nest,
        Gobolt,
        Worm
    }


}
