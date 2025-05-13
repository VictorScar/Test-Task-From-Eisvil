using System;
using TestTaskEisvil.Character;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace TestTaskEisvil.InputSystem
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private PlayerPawn _pawn;
        private IInputAdapter _inputAdapter;

        public bool IsEnabled
        {
            set { _inputAdapter.IsEnabled = value; }
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
                var moveInput = _inputAdapter.GetMovementInput();
                _pawn.Move(moveInput.y);
                _pawn.Rotate(moveInput.x);

                if (_inputAdapter.IsShootInput)
                {
                    _pawn.Attack();
                }

                var changeWeaponValue = _inputAdapter.ChangeWeaponInput();

                if (changeWeaponValue != 0)
                {
                    _pawn.ChangeWeapon(changeWeaponValue);
                }
                
            }
        }

        public void Init(IInputAdapter inputAdapter)
        {
            _inputAdapter = inputAdapter;
        }
    }
}