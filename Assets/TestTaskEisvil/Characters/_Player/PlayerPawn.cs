using TestTaskEisvil.Characters;
using TestTaskEisvil.Characters._Player;
using TestTaskEisvil.Characters._Player.Components;
using TestTaskEisvil.Configs;
using UnityEngine;
using UnityEngine.Serialization;

namespace TestTaskEisvil.Character
{
    public class PlayerPawn : MonoBehaviour, IDamageSource, IDamageReceiver
    {
        [SerializeField] private HealthController health;
        [SerializeField] private PlayerMover mover;
        [SerializeField] private CombatController combatController;
        [SerializeField] private PawnParameters _parameters;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private EquipController equipController;

        private PawnData _data;

        public void Init(PawnData data)
        {
            _data = data;
            mover.Init(rb);
            equipController.Init();
            combatController.Init(new CombatControllerData
            {
                DamageSource = this,
                EquipController = equipController
            });
        }

        public void Move(float moveInput)
        {
            mover.Move(moveInput, _data.BaseMoveSpeed);
        }

        public void Rotate(float angle)
        {
            mover.Rotate(angle, _data.BaseRotateSpeed);
        }

        public void Attack()
        {
            combatController.Attack();
        }

        public void ChangeWeapon(int changeDirection)
        {
            Debug.Log("Change Weapon at " + changeDirection);
        }

        public void ReceiveDamage(int damage, IDamageSource source)
        {
            health.ReceiveDamage(damage);
        }
    }
}