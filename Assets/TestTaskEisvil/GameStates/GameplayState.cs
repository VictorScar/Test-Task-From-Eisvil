using UnityEngine;

namespace TestTaskEisvil.GameStates
{
    public class GameplayState : GameStateBase
    {
        public override void Enter()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }
}
