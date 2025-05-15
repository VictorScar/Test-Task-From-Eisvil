using UnityEngine;

namespace TestTaskEisvil.Characters._AI._Components.States
{
    public class BattleAIState : AiStateBase
    {
        public override void Enter()
        {
            Debug.Log("Attack State");
        }

        public override void UpdateState(float deltaTime)
        {
            if (Vector3.Distance(_data.Pawn.Target.Body.position, _data.Pawn.transform.position) >
                _data.Pawn.AttackDistance)
            {
                _data.StateController.SetState<ChaesingAIState>();
            }
            else
            {
                Debug.Log("NPC Attack");
            }
        }
    }
}