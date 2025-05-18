using System;
using UnityEngine;

namespace TestTaskEisvil.Characters._AI._Components
{
    public class AIAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private AIMover mover;
        [SerializeField] private AICombatController combatController;

        private void OnEnable()
        {
          //  animator.SetTrigger("Reset");
            mover.onMoving += IsMoving;
            combatController.onAttack += AttackAnimation;
        }


        private void OnDisable()
        {
            mover.onMoving -= IsMoving;
            combatController.onAttack -= AttackAnimation;
        }

        public void ResetAnimations()
        {
            animator.SetBool("IsDead", false);
        }
        
        public void AttackAnimation()
        {
            animator.SetTrigger("Attack");
        }

        public void DeadAnimation()
        {
            animator.SetBool("IsDead", true);
        }
        
        private void IsMoving(bool isMoving)
        {
            animator.SetBool("IsMoving", isMoving);
        }

    }
}