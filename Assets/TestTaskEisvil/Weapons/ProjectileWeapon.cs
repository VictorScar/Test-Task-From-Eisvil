using System;
using TestTaskEisvil.Characters;
using UnityEngine;

namespace TestTaskEisvil.Weapons
{
    public class ProjectileWeapon : WeaponBase
    {
        [SerializeField] private Shell projectilePrefab;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private float maxProjectileLifeTime;

        private float _cooldown;
        
        public override void Shoot(IDamageSource source)
        {
            if (_cooldown <= 0)
            {
                var shell = Instantiate(projectilePrefab, muzzle.position, muzzle.rotation, transform);
                shell.Init(damage, projectileSpeed, source, maxProjectileLifeTime);
                _cooldown = rateOfFire;
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
}
