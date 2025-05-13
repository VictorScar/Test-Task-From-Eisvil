using System;
using TestTaskEisvil.Character;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace TestTaskEisvil.InputSystem
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private InputData _inputData;
        [SerializeField] private PlayerPawn _pawn;

        private GameInput _gameInput;
  
        public bool IsActive
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

        public PlayerPawn Pawn
        {
            get => _pawn;
            set => _pawn = value;
        }

        private void Update()
        {
            if (_pawn)
            {
                var moveInput = _gameInput.Gameplay.Movement.ReadValue<Vector2>();
                _pawn.Move(moveInput.y);
                _pawn.Rotate(moveInput.x);

                if (_gameInput.Gameplay.Shoot.IsPressed())
                {
                    _pawn.Attack();
                }

                _pawn.ChangeWeapon((int)_gameInput.Gameplay.MouseWheel.ReadValue<Vector2>().y);
            }
        }
        
        public void Init()
        {
            _gameInput = new GameInput();
            _gameInput.Enable();
        }
    }
}