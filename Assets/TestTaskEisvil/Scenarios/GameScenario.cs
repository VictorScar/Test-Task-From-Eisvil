using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace TestTaskEisvil.Scenarios
{
    public abstract class GameScenario<T> : ScenarioBase where T: IScenarioData
    {
        protected CancellationTokenSource _internalTokenSource;
        protected T _data;
        protected bool _isStopped;
    
        public void Init(T data)
        {
            _data = data;
            OnInit(data);
        }

        protected virtual void OnInit(T data)
        {
           
        }


        public async UniTask Run(CancellationToken token)
        {
            _isStopped = false;
            _internalTokenSource = CancellationTokenSource.CreateLinkedTokenSource(token);
            await OnBeforeScenario(_internalTokenSource.Token);
            await RunInternal(_internalTokenSource.Token);
            OnScenarioEnd();
        }

        public void ForceEndScenario()
        {
            _isStopped = true;
        }

        protected virtual UniTask OnBeforeScenario(CancellationToken token)
        {
            return UniTask.CompletedTask;
        }

        protected virtual void OnScenarioEnd()
        {
        
        }

        protected abstract UniTask RunInternal(CancellationToken token);

    }
}
