using UnityEngine;

namespace TestTaskEisvil.Characters._AI._Components.States
{
    public class SearchingState : AiStateBase
    {
        public override void Enter()
        {
           Debug.Log("Search");
           _data.Collider.enabled = true;
           if (!_data.HealthController.IsDead)
           {
               _data.AnimationController.ResetAnimations();
           }
           else
           {
               _data.StateController.SetState<DeadAiState>();
           }
        }

        public override void UpdateState(float deltaTime)
        {
            if (!_data.HealthController.IsDead)
            {
                if (_data.Pawn.Target != null && _data.Pawn.Target.IsAlive)
                {
                    _data.StateController.SetState<ChaesingAIState>();
                }
                else
                {
                    if (_data.Level.Tower!= null && _data.Level.Tower.IsAlive)
                    {
                        _data.Pawn.Target = _data.Level.Tower;
                    }
                }
            }
            else
            {
                _data.StateController.SetState<DeadAiState>();
            }
           
        }
        
        
    }
}
