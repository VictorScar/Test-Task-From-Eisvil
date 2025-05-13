using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using ScarFramework.UI;
using TestTaskEisvil._Level;
using TestTaskEisvil.Character;
using TestTaskEisvil.Configs;
using TestTaskEisvil.Core;
using TestTaskEisvil.InputSystem;
using UnityEngine;

public class LevelScenario : GameScenarioBase<LevelScenarioData>
{
    protected override UniTask RunInternal(CancellationToken token)
    {
        var player = SpawnPlayer();
        _data.Level.PlayerPawn = player;
        _data.InputController.Pawn = player;
        _data.InputController.IsEnabled = true;
        
        return UniTask.CompletedTask;
    }

    private PlayerPawn SpawnPlayer()
    {
        var player = Instantiate(_data.PawnConfig.PawnPrefab, _data.Level.SpawnPoint.Position, 
            _data.Level.SpawnPoint.Rotation, _data.Level.transform);
        player.Init(_data.PawnConfig.PawnData);
        return player;
    }
}

public struct LevelScenarioData
{
    public Level Level;
    public UISystem UISystem;
    public Player Player;
    public InputController InputController;
    public PlayerPawnConfig PawnConfig;
}
