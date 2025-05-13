using UnityEngine;

namespace TestTaskEisvil.InputSystem
{
    public class NewInputSystemAdapter : IInputAdapter
    {
        private GameInput _gameInput;
    
        public bool IsEnabled
        {
            set
            {
                if (value)
                {
                    _gameInput.Enable();
                }
                else
                {
                    _gameInput.Disable();
                }
            }
        }
        public bool IsShootInput { get => _gameInput.Gameplay.Shoot.IsPressed(); }
        
        public bool IsMenuButton { get; }



        public NewInputSystemAdapter()
        {
            _gameInput = new GameInput();
        }

    
        public Vector2 GetMovementInput()
        {
            return _gameInput.Gameplay.Movement.ReadValue<Vector2>();
        }

        public int ChangeWeaponInput()
        {
            return (int)_gameInput.Gameplay.MouseWheel.ReadValue<Vector2>().y;
        }
    }
}
