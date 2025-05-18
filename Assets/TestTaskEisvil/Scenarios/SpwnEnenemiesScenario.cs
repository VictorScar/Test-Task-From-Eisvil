using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using TestTaskEisvil._Level;
using TestTaskEisvil.Characters._AI;
using TestTaskEisvil.Scenarios;
using UnityEngine;

public class SpwnEnenemiesScenario : GameScenario<SpawnEnemiesScenarioData>
{
    protected override async UniTask RunInternal(CancellationToken token)
    {
       
    }
}

public struct SpawnEnemiesScenarioData: IScenarioData
{
    public Nest[] Nests;
    public NPCControlSystem NpcControlSystem;
}
