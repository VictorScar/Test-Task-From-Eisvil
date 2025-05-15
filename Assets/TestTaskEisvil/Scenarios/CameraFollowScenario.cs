using System.Threading;
using Cysharp.Threading.Tasks;
using TestTaskEisvil._Level;
using UnityEngine;

namespace TestTaskEisvil.Scenarios
{
    public class CameraFollowScenario : GameScenario<CameraFollowScenarioData>
    {
        protected override async UniTask RunInternal(CancellationToken token)
        {
            var gameCamera = _data.GameCamera;
            var target = _data.Target;
           
            while (!token.IsCancellationRequested && gameCamera && target)
            {
                gameCamera.Position = target.position - _data.CameraOffset;
                await UniTask.Yield(token);
            }
        }
    }

    public struct CameraFollowScenarioData : IScenarioData
    {
        public GameCamera GameCamera;
        public Transform Target;
        public Vector3 CameraOffset;
        public float CameraMoveSpeed;
    }
}