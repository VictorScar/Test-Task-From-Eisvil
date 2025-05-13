using System;
using ScarFramework.UI;
using TestTaskEisvil.Character;
using TestTaskEisvil.Core;
using UnityEngine;

namespace TestTaskEisvil._Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private PlayerSpawnPoint playerSpawn;
        [SerializeField] private PlayerPawn pawn;
        
        private LevelInitData _initData;

        private void Start()
        {
            GameServiceProvider.I.RegisterLevel(this);
        }

        public void Init(LevelInitData initData)
        {
            _initData = initData;
            Debug.Log("Level Init");
            pawn.Init();
            initData.Player.Pawn = pawn;
            initData.Player.InputController.IsEnabled = true;
        }
    }

    public struct LevelInitData
    {
        public UISystem UISystem;
        public Player Player;
    }
}
