using UnityEngine;

namespace TestTaskEisvil.Character
{
    public class PlayerPawn : MonoBehaviour
    {
        [SerializeField] private HealthController _health;
        [SerializeField] private PlayerMover _mover;
        [SerializeField] private ShootControler _shootControler;
        [SerializeField] private PawnParameters _parameters;
        [SerializeField] private CharacterController charController;
        
        public void Init()
        {
            _mover.Init(charController);
        }
        
        public void Move(float moveInput)
        {
            _mover.Move(moveInput, _parameters.MoveSpeed);
        }

        public void Rotate(float angle)
        {
            _mover.Rotate(angle, _parameters.RotationSpeed);
        }

        public void Attack()
        {
            Debug.Log("Attack");
        }

        public void ChangeWeapon(int changeDirection)
        {
            Debug.Log("Change Weapon at " + changeDirection);
        }
    }
}