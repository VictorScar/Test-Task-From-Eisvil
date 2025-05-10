using System;
using UnityEngine;

namespace TestTaskEisvil.Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Game gamePrefab;

        private Game _game;
        
        private void Start()
        {
            _game = Instantiate(gamePrefab);
            _game.Init();
        }
    }
}