using UnityEngine;

namespace TestTaskEisvil.GameStates
{
    public abstract class GameStateBase
    {
        public abstract void Enter();

        public virtual void Exit()
        {
        }
    }
}