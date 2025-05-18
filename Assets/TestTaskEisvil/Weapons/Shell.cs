using System;
using TestTaskEisvil.Characters;
using UnityEngine;

namespace TestTaskEisvil.Weapons
{
    public class Shell : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        private int _damage;
        private IDamageSource _source;

        public event Action<Shell> onDespawn;

        public void Init(int damage, float shellSpeed, IDamageSource source)
        {
            _damage = damage;
            _source = source;

            rb.AddForce(transform.forward * shellSpeed, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IDamageReceiver>(out var target))
            {
                target.ReceiveDamage(_damage, _source);
            }

            Despawn();
        }

        private void Despawn()
        {
            //onDespawn?.Invoke(this);
            Destroy(gameObject);
        }
    }
}