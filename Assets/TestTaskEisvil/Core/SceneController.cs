using System.Threading;
using Cysharp.Threading.Tasks;
using ScarFramework.UI;
using TestTaskEisvil._Level;
using TestTaskEisvil.Configs;
using TestTaskEisvil.Scenarios;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestTaskEisvil.Core
{
    public class SceneController : MonoBehaviour
    {
        private Level _currentLevel;
        private LevelControllerData _data;
        public Level CurrentLevel
        {
            get => _currentLevel;
            set => _currentLevel = value;
        }

        public void Init(LevelControllerData data)
        {
            _data = data;
            _currentLevel = null;
        }

        public async UniTask LoadGame()
        {
            var levelLoading = SceneManager.LoadSceneAsync("GameScene");
            await UniTask.WaitUntil(() => levelLoading.isDone);
            await UniTask.WhenAny(UniTask.WaitUntil(() => _currentLevel != null),
                UniTask.WaitForSeconds(_data.LevelConfig.MaxLoadingTime));

            if (_currentLevel)
            {
                _currentLevel.Init(new LevelInitData
                {
                    Player = _data.Player,
                    UISystem = _data.UISystem, 
                    PawnConfig = _data.PawnConfig, 
                    ScenariosContainer = _data.ScenariosContainer, 
                    CancellationToken = _data.CancelationToken, 
                    NpcConfig = _data.NpcConfig,
                    CameraSettings = _data.LevelConfig.CameraSettings,
                    TasksConfig = _data.LevelConfig.TasksConfig,
                    GameStateController = _data.GameStateController
                });
            }
            else
            {
                Debug.Log("Level not found!");
            }
        }
    }

    public struct LevelControllerData
    {
        public Player Player;
        public UISystem UISystem;
        public LevelConfig LevelConfig;
        public NpcConfig NpcConfig;
        public PlayerPawnConfig PawnConfig;
        public ScenariosContainer ScenariosContainer;
        public CancellationToken CancelationToken;
        public GameStateController GameStateController;
    }
}