using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using ScarFramework.UI;
using TestTaskEisvil.Character;
using TestTaskEisvil.Characters;
using TestTaskEisvil.Characters._Player;
using TestTaskEisvil.Configs;
using TestTaskEisvil.Core;
using TestTaskEisvil.Scenarios;
using UnityEngine;

namespace TestTaskEisvil._Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private PlayerSpawnPoint playerSpawn;
       [SerializeField] private GameCamera gameCamera;
       [SerializeField] private Tower tower;
       
        private LevelInitData _initData;
        
        public PlayerPawn PlayerPawn { get; set; }
        public PlayerSpawnPoint SpawnPoint => playerSpawn;
        public GameCamera GameCamera => gameCamera;
        public Tower Tower => tower;

        private void Start()
        {
            GameServiceProvider.I.RegisterLevel(this);
        }

        public void Init(LevelInitData initData)
        {
            _initData = initData;
            Debug.Log("Level Init");
            var levelScenario = _initData.ScenariosContainer.GetScenario<LevelScenario>();
            levelScenario.Init(new LevelScenarioData
            {
                Level = this, UISystem = _initData.UISystem,
                Player = _initData.Player,
                InputController = _initData.Player.InputController,
                PawnConfig = initData.PawnConfig,
                ScenariosContainer = _initData.ScenariosContainer
            });

            levelScenario.Run(_initData.CancellationToken);
        }
    }

    public struct LevelInitData
    {
        public UISystem UISystem;
        public Player Player;
        public PlayerPawnConfig PawnConfig;
        public ScenariosContainer ScenariosContainer;
        public CancellationToken CancellationToken;
    }
}
