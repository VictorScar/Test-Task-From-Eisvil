using UnityEngine;

namespace TestTaskEisvil.GameStates
{
    public class MenuState : GameStateBase
    {
        public override void Enter()
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
