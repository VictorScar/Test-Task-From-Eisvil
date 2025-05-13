using TestTaskEisvil.Characters._Player;
using TestTaskEisvil.Characters._Player.Components;
using TestTaskEisvil.Configs;
using UnityEngine;
using UnityEngine.Serialization;

namespace TestTaskEisvil.Character
{
    public class PlayerPawn : MonoBehaviour
    {
        [SerializeField] private HealthController _health;
        [SerializeField] private PlayerMover _mover;
        [SerializeField] private CombatController combatController;
        [SerializeField] private PawnParameters _parameters;
        [SerializeField] private Rigidbody rb;

        private PawnData _data;

        public void Init(PawnData data)
        {
            _data = data;
            _mover.Init(rb);
        }

        public void Move(float moveInput)
        {
            _mover.Move(moveInput, _data.BaseMoveSpeed);
        }

        public void Rotate(float angle)
        {
            _mover.Rotate(angle, _data.BaseRotateSpeed);
        }

        public void Attack()
        {
            combatController.Attack();
        }

        public void ChangeWeapon(int changeDirection)
        {
            Debug.Log("Change Weapon at " + changeDirection);
        }
    }
}