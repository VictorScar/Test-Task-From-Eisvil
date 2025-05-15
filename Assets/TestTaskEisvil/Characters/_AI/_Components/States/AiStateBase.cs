using TestTaskEisvil._Level;
using UnityEngine;

namespace TestTaskEisvil.Characters._AI._Components.States
{
    public abstract class AiStateBase : MonoBehaviour
    {
        [SerializeField] protected AiStateID stateID;
        protected AIStateData _data;
        public AiStateID StateID => stateID;

        public void Init(AIStateData data)
        {
            _data = data;
        }

        public abstract void Enter();

        public virtual void Exit()
        {
        }

        public virtual void UpdateState(float deltaTime)
        {
        }
    }

    public enum AiStateID
    {
        None,
        Default,
        Chasing,
        Attack
    }

    public struct AIStateData
    {
        public AIStateController StateController;
        public AIMover Mover;
        public HealthController HealthController;
        public AICombatController CombatController;
        public Level Level;
        public Monster Pawn;
    }
}