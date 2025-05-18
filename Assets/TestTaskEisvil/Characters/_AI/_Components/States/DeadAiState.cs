using System.Threading;
using Cysharp.Threading.Tasks;

namespace TestTaskEisvil.Characters._AI._Components.States
{
    public class DeadAiState : AiStateBase
    {
        public override void Enter()
        {
            _data.Collider.enabled = false;
            _data.Mover.StopMove();
            _data.AnimationController.DeadAnimation();
            _data.Pawn.Die();
        }
    }
}
