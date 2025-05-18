using TestTaskEisvil.Characters;
using UnityEngine;

namespace TestTaskEisvil.Weapons
{
    public abstract class WeaponBase : MonoBehaviour
    {
        [SerializeField] protected Transform muzzle;
        [SerializeField] protected int damage;
        [SerializeField] protected float rateOfFire;
        [SerializeField] protected float maxDistance;
        public abstract void Shoot(IDamageSource source);
    }
}