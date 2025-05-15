using TestTaskEisvil.Characters._AI._Components;
using UnityEngine;

namespace TestTaskEisvil.Characters
{
    public class Tower : MonoBehaviour, IAiTarget
    {
        [SerializeField] private HealthController healthController;
    
        public void ReceiveDamage(int damage)
        {
            healthController.ReceiveDamage(damage);
        }

        public Transform Body => transform;
        public bool IsAlive => !healthController.IsDead;
    }
}
