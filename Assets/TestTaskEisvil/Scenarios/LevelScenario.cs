using System.Threading;
using Cysharp.Threading.Tasks;
using ScarFramework.UI;
using TestTaskEisvil._Level;
using TestTaskEisvil._Level.Scenarios;
using TestTaskEisvil.Character;
using TestTaskEisvil.Configs;
using TestTaskEisvil.Core;
using TestTaskEisvil.InputSystem;
using UnityEngine;

namespace TestTaskEisvil.Scenarios
{
    public class LevelScenario : GameScenario<LevelScenarioData>
    {
        protected override async UniTask RunInternal(CancellationToken token)
        {
            var player = SpawnPlayer();
            _data.Level.PlayerPawn = player;
            _data.InputController.Pawn = player;

            var startCameraScenario = _data.ScenariosContainer.GetScenario<StartCameraScenario>();
            startCameraScenario.Init(new CameraScenarioData
            {
                Camera = _data.Level.GameCamera, 
                Target = _data.Level.PlayerPawn.transform,
                StartCameraPoint = _data.Level.GameCamera.Position,
                CameraMoveSpeed = 10f,
                CameraOffset = 12f
            });

            await startCameraScenario.Run(_internalTokenSource.Token);

            var followCameraScenario = _data.ScenariosContainer.GetScenario<CameraFollowScenario>();
            followCameraScenario.Init(new CameraFollowScenarioData
            {
                GameCamera = _data.Level.GameCamera,
                Target = _data.Level.PlayerPawn.transform,
                CameraMoveSpeed = 5f,
                CameraOffset = _data.Level.PlayerPawn.transform.position - _data.Level.GameCamera.Position
            });
            
            followCameraScenario.Run(_internalTokenSource.Token).Forget();
            
            
            _data.InputController.IsEnabled = true;
            Debug.Log("Start Game");
       
        }

        private PlayerPawn SpawnPlayer()
        {
            var player = Instantiate(_data.PawnConfig.PawnPrefab, _data.Level.SpawnPoint.Position, 
                _data.Level.SpawnPoint.Rotation, _data.Level.transform);
            player.Init(_data.PawnConfig.PawnData);
            return player;
        }
    }

    public struct LevelScenarioData: IScenarioData
    {
        public Level Level;
        public UISystem UISystem;
        public Player Player;
        public InputController InputController;
        public PlayerPawnConfig PawnConfig;
        public ScenariosContainer ScenariosContainer;
    }
}