using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class GameScenarioBase<T> : MonoBehaviour //where T: IScenarioData
{
    private CancellationTokenSource _internalTokenSource;
    
    public void Init<T>(T data)
    {
       
    }

    public async UniTask Run(CancellationToken token)
    {
        _internalTokenSource = CancellationTokenSource.CreateLinkedTokenSource(token);
        await OnBeforeScenario(_internalTokenSource.Token);
        await RunInternal(_internalTokenSource.Token);
        OnScenarioEnd();
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
