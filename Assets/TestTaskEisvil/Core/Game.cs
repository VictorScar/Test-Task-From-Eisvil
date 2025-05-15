using System.Threading;
using Cysharp.Threading.Tasks;
using ScarFramework.UI;
using TestTaskEisvil.Configs;
using TestTaskEisvil.InputSystem;
using TestTaskEisvil.Scenarios;
using TestTaskEisvil.UI;
using UnityEngine;

namespace TestTaskEisvil.Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private GameConfig gameConfig;
        [SerializeField] private UISystem uiSystem;
        [SerializeField] private Player player;
        [SerializeField] private SceneController _sceneController;
        [SerializeField] private ScenariosContainer scenariosContainer;

        private GameServiceProvider _serviceProvider;
        private CancellationTokenSource _gameCancelationTokenSource;
        
        public async UniTask Init()
        {
            _gameCancelationTokenSource = new CancellationTokenSource();
            var inputAdapter = new NewInputSystemAdapter();
            player.Init(inputAdapter);
            _sceneController.Init(new LevelControllerData{Player = player, UISystem = uiSystem, 
                LevelConfig = gameConfig.LevelConfig, PawnConfig = gameConfig.PawnConfig, 
                ScenariosContainer = scenariosContainer, CancelationToken = _gameCancelationTokenSource.Token});
            _serviceProvider = new GameServiceProvider(new ServiceProviderData
                { SceneController = _sceneController, UISystem = uiSystem });

            DontDestroyOnLoad(gameObject);

            await _sceneController.LoadGame();

            var loadingScreen = uiSystem.GetScreen<LoadingScreen>();
            loadingScreen.Hide();
        }
    }
}