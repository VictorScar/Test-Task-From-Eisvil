using System;
using System.Threading;
using ScarFramework.UI;
using TestTaskEisvil.Character;
using TestTaskEisvil.Characters._Player;
using TestTaskEisvil.Configs;
using TestTaskEisvil.Core;
using UnityEngine;

namespace TestTaskEisvil._Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private PlayerSpawnPoint playerSpawn;
        [SerializeField] private LevelScenario scenario;
        
        private LevelInitData _initData;
        public PlayerPawn PlayerPawn { get; set; }
        public PlayerSpawnPoint SpawnPoint => playerSpawn;

        private void Start()
        {
            GameServiceProvider.I.RegisterLevel(this);
        }

        public void Init(LevelInitData initData)
        {
            _initData = initData;
            Debug.Log("Level Init");
            scenario.Init(new LevelScenarioData
            {
                Level = this, UISystem = _initData.UISystem,
                Player = _initData.Player,
                InputController = _initData.Player.InputController,
                PawnConfig = initData.PawnConfig
            });

            scenario.Run(CancellationToken.None);
        }
    }

    public struct LevelInitData
    {
        public UISystem UISystem;
        public Player Player;
        public PlayerPawnConfig PawnConfig;
    }
}
