using System;
using TestTaskEisvil.Character;
using TestTaskEisvil.InputSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace TestTaskEisvil.Core
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private InputController inputController;
        private PlayerPawn _pawn;

        public void Init()
        {
        }

        private void Update()
        {
            if (inputController.IsActive)
            {
                inputController.UpdateInputs();
            }
        }
    }
}