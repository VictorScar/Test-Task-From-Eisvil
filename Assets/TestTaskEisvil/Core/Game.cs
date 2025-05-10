using Cysharp.Threading.Tasks;
using ScarFramework.UI;
using TestTaskEisvil.Configs;
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

        private GameServiceProvider _serviceProvider;

        public async UniTask Init()
        {
            _sceneController.Init(gameConfig.LevelConfig);
            player.Init();
            _serviceProvider = new GameServiceProvider(new ServiceProviderData
                { SceneController = _sceneController, UISystem = uiSystem });

            DontDestroyOnLoad(gameObject);

            await _sceneController.LoadGame();

            var loadingScreen = uiSystem.GetScreen<LoadingScreen>();
            loadingScreen.Hide();
        }
    }
}