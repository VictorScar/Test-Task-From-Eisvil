using System.Threading;
using Cysharp.Threading.Tasks;
using TestTaskEisvil.Character;
using TestTaskEisvil.Scenarios;
using UnityEngine;

namespace TestTaskEisvil._Level.Scenarios
{
    public class StartCameraScenario : GameScenario<CameraScenarioData>
    {
        protected override async UniTask RunInternal(CancellationToken token)
        {
            _data.Camera.Position = _data.StartCameraPoint;
            var toTargetDirection = (_data.Target.position - _data.Camera.Position).normalized;
            _data.Camera.Rotation = Quaternion.LookRotation(toTargetDirection);
            
            while (!token.IsCancellationRequested &
                   Vector3.Distance(_data.Camera.transform.position, _data.Target.position) >
                   _data.CameraOffset)
            {
                _data.Camera.Position += toTargetDirection * _data.CameraMoveSpeed * Time.deltaTime;
                await UniTask.Yield();
            }
        }
    }

    public struct CameraScenarioData: IScenarioData
    {
        public GameCamera Camera;
        public Transform Target;
        public Vector3 StartCameraPoint;
        public float CameraOffset;
        public float CameraMoveSpeed;
    }
}