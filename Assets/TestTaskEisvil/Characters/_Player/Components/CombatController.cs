using UnityEngine;

namespace TestTaskEisvil.Characters._Player.Components
{
    public class CombatController : MonoBehaviour
    {
        private IDamageSource _damageSource;
        private EquipController _equipController;
        
        public void Init(CombatControllerData data)
        {
            _damageSource = data.DamageSource;
            _equipController = data.EquipController;
        }
        
        public void Attack()
        {
            //Debug.Log("Attack!");
            _equipController.CurrentWeapon?.Shoot(_damageSource);
        }
    }

    public struct CombatControllerData
    {
        public IDamageSource DamageSource;
        public EquipController EquipController;
    }
}
