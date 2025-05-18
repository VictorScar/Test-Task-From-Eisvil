using System.Collections;
using System.Collections.Generic;
using TestTaskEisvil.Characters._AI;
using TestTaskEisvil.Characters._AI._Components.States;
using UnityEngine;

public class ChaesingAIState : AiStateBase
{
    [SerializeField] private LayerMask layerMask;
    private Monster _pawn;

    public override void Enter()
    {
        _pawn = _data.Pawn;
        Debug.Log("Chaesing");
    }

    public override void UpdateState(float deltaTime)
    {
        if (!_data.HealthController.IsDead)
        {
            if (_pawn.Target != null)
            {
                if (Vector3.Distance(_pawn.Target.Body.position, _pawn.transform.position) > _pawn.AttackDistance-0.5f)
                {
                    _pawn.MoveTo(_pawn.Target.Body.position);
                }
                else
                {
                    _pawn.LookAt(_pawn.Target.Body.position);
                    _pawn.StopMove();
                    Attack();
                }
            }
        }
        else
        {
            _data.StateController.SetState<DeadAiState>();
        }
       
    }

    private void Attack()
    {
      _data.CombatController.Attack();
    }
}