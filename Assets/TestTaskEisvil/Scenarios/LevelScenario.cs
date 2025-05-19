using System.Threading;
using Cysharp.Threading.Tasks;
using ScarFramework.UI;
using TestTaskEisvil._Level;
using TestTaskEisvil._Level.Scenarios;
using TestTaskEisvil.Character;
using TestTaskEisvil.Configs;
using TestTaskEisvil.Core;
using TestTaskEisvil.InputSystem;
using TestTaskEisvil.UI;
using UnityEngine;

namespace TestTaskEisvil.Scenarios
{
    public class LevelScenario : GameScenario<LevelScenarioData>
    {
        private GameScreen _gameScreen;
        private Level _level;

        protected override void OnInit(LevelScenarioData data)
        {
            _gameScreen = _data.UISystem.GetScreen<GameScreen>();
        }

        protected override UniTask OnBeforeScenario(CancellationToken token)
        {
            _level = _data.Level;
            return base.OnBeforeScenario(token);
        }

        protected override async UniTask RunInternal(CancellationToken token)
        {
            var player = SpawnPlayer();
            _level.PlayerPawn = player;
            _data.InputController.Pawn = player;

            var startCameraScenario = _data.ScenariosContainer.GetScenario<StartCameraScenario>();
            startCameraScenario.Init(new CameraScenarioData
            {
                Camera = _data.Level.GameCamera,
                Target = _data.Level.PlayerPawn.transform,
                StartCameraPoint = _data.Level.GameCamera.Position,
                CameraMoveSpeed = _data.CameraSettings.StartCamersSpeed,
                CameraOffset = _data.CameraSettings.StartCameraOffset
            });

            await startCameraScenario.Run(_internalTokenSource.Token);

            var followCameraScenario = _data.ScenariosContainer.GetScenario<CameraFollowScenario>();
            followCameraScenario.Init(new CameraFollowScenarioData
            {
                GameCamera = _data.Level.GameCamera,
                Target = _data.Level.PlayerPawn.transform,
                CameraMoveSpeed = _data.CameraSettings.CameraFollowSpeed,
                CameraOffset = _level.PlayerPawn.transform.position - _level.GameCamera.Position
            });

            followCameraScenario.Run(_internalTokenSource.Token).Forget();

            var levelTimerScenario = _data.ScenariosContainer.GetScenario<LevelTimerScenario>();
            levelTimerScenario.Init(new LevelTimerScenarioData
            {
                Timer = _level.LevelTimer,
                TimerViewPanel = _gameScreen.TimeIndicator
            });

            levelTimerScenario.Run(_internalTokenSource.Token).Forget();

            _data.InputController.IsEnabled = true;
            Debug.Log("Start Game");

            _gameScreen.Show();
            _level.NpcControlSystem.Init(_data.Level, _data.NpcConfig);

            /*await UniTask.WhenAny(UniTask.WaitUntilCanceled(token),
                UniTask.WaitUntil(() => _isStopped, cancellationToken: token));*/

            var tasksScenario = _data.ScenariosContainer.GetScenario<LevelTaskScenario>();
            tasksScenario.Init(new LevelTaskScenarioData
            {
                Level = _level,
                TasksConfig = _level.TasksConfig,
                UISystem = _data.UISystem
            });

            await tasksScenario.Run(token);
            
            Debug.LogError("Victory!");
        }

        private PlayerPawn SpawnPlayer()
        {
            var player = Instantiate(_data.PawnConfig.PawnPrefab, _level.SpawnPoint.Position,
                _level.SpawnPoint.Rotation, _data.Level.transform);
            player.Init(_data.PawnConfig.PawnData);
            return player;
        }
    }

    public struct LevelScenarioData : IScenarioData
    {
        public Level Level;
        public UISystem UISystem;
        public Player Player;
        public InputController InputController;
        public PlayerPawnConfig PawnConfig;
        public ScenariosContainer ScenariosContainer;
        public NpcConfig NpcConfig;
        public LevelCameraSettings CameraSettings;
    }
}