using System;
using TestTaskEisvil.Character;
using TestTaskEisvil.InputSystem;
using UnityEngine;

namespace TestTaskEisvil.Core
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private InputController inputController;

        public PlayerPawn Pawn
        {
            get => inputController.Pawn;
            set => inputController.Pawn = value;
        }

        public InputController InputController => inputController;

        public void Init(IInputAdapter inputAdapter)
        {
            inputController.Init(inputAdapter);
        }
    }
}