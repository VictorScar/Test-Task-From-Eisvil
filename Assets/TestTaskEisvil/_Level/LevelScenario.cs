using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using ScarFramework.UI;
using TestTaskEisvil._Level;
using UnityEngine;

public class LevelScenario : GameScenarioBase<LevelScenarioData>
{
    
    
    protected override UniTask RunInternal(CancellationToken token)
    {
        return UniTask.CompletedTask;
    }
}

public struct LevelScenarioData
{
    public Level Level;
    public UISystem UISystem;
}
