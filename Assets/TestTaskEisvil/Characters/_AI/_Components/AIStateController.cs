using TestTaskEisvil._Level;
using TestTaskEisvil.Characters._AI._Components.States;
using UnityEngine;

namespace TestTaskEisvil.Characters._AI._Components
{
    public class AIStateController : MonoBehaviour
    {
        [SerializeField] private AiStateBase[] states;

        private AiStateBase _currentState;

        public void UpdateState()
        {
            _currentState?.UpdateState(Time.deltaTime);
        }

        public void Init(AiStateControllerData data)
        {
            if (states != null)
            {
                foreach (var state in states)
                {
                    state.Init(new AIStateData
                    {
                        StateController = this,
                        Mover = data.Mover,
                        HealthController = data.HealthController,
                        CombatController = data.CombatController,
                        Level = data.Level,
                        Pawn = data.Pawn,
                        AnimationController = data.AnimationController,
                        Collider = data.Collider
                    });
                }
            }
        }

        public void Run()
        {
            SetState<SearchingState>();
        }

        public bool SetState<T>() where T : AiStateBase
        {
            if (states != null)
            {
                foreach (var state in states)
                {
                    if (state is T typedState)
                    {
                        SetStateInternal(typedState);
                        return true;
                    }
                }
            }

            return false;
        }

        public bool SetState(AiStateID newStateID)
        {
            if (states != null)
            {
                foreach (var state in states)
                {
                    if (state.StateID == newStateID)
                    {
                        SetStateInternal(state);
                        return true;
                    }
                }
            }

            return false;
        }

        private void SetStateInternal(AiStateBase newState)
        {
            if (_currentState)
            {
                _currentState.Exit();
            }

            _currentState = newState;
            _currentState.Enter();
        }
    }

    public struct AiStateControllerData
    {
        public AIMover Mover;
        public AICombatController CombatController;
        public HealthController HealthController;
        public Level Level;
        public Monster Pawn;
        public AIAnimationController AnimationController;
        public Collider Collider;
    }
}