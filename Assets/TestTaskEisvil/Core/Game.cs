using System.Threading;
using Cysharp.Threading.Tasks;
using ScarFramework.UI;
using TestTaskEisvil.Configs;
using TestTaskEisvil.InputSystem;
using TestTaskEisvil.Scenarios;
using TestTaskEisvil.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace TestTaskEisvil.Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameConfig gameConfig;
        [SerializeField] private UISystem uiSystem;
        [SerializeField] private Player player;

        [FormerlySerializedAs("levelontroller")] [FormerlySerializedAs("_sceneController")] [SerializeField]
        private LevelController levelController;

        [SerializeField] private ScenariosContainer scenariosContainer;
        [SerializeField] private GameStateController gameStateController;

        private GameServiceProvider _serviceProvider;
        private CancellationTokenSource _gameCancelationTokenSource;

        public async UniTask Init()
        {
            _gameCancelationTokenSource = new CancellationTokenSource();
            var inputAdapter = new NewInputSystemAdapter();
            player.Init(inputAdapter);

            levelController.Init(new LevelControllerData
            {
                Player = player, UISystem = uiSystem,
                LevelConfig = gameConfig.LevelConfig,
                PawnConfig = gameConfig.PawnConfig,
                NpcConfig = gameConfig.NpcConfig,
                ScenariosContainer = scenariosContainer,
                CancelationToken = _gameCancelationTokenSource.Token,
                GameStateController = gameStateController
            });
            gameStateController.Init(levelController);
            _serviceProvider = new GameServiceProvider(new ServiceProviderData
                { LevelController = levelController, UISystem = uiSystem });

            DontDestroyOnLoad(gameObject);

            await levelController.LoadGame();
          
        }
    }
}