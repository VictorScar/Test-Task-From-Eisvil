using TestTaskEisvil.Weapons;
using UnityEngine;

namespace TestTaskEisvil.Characters._Player
{
    public class EquipController : MonoBehaviour
    {
        [SerializeField] private WeaponBase currentWeapon;
        [SerializeField] private Transform weaponSocket;
        public WeaponBase CurrentWeapon => currentWeapon;

        public void Init()
        {
            if (!currentWeapon)
            {
                if(weaponSocket.TryGetComponent<WeaponBase>(out var weapon))
                {
                    currentWeapon = weapon;
                }
            }
        }
    }
}