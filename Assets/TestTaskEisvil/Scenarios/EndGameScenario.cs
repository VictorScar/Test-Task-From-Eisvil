using System.Threading;
using Cysharp.Threading.Tasks;
using ScarFramework.UI;
using TestTaskEisvil.Core;
using TestTaskEisvil.GameStates;
using TestTaskEisvil.UI;
using UnityEngine;

namespace TestTaskEisvil.Scenarios
{
    public class EndGameScenario : GameScenario<EndGameScenarioData>
    {
        [SerializeField] private EndGameScreenData winScreenData;
        [SerializeField] private EndGameScreenData loseScreenData;
        
        private EndGameScreen _endGameScreen;

        protected override void OnInit(EndGameScenarioData data)
        {
            _endGameScreen = _data.UISystem.GetScreen<EndGameScreen>();
        }

        protected override UniTask OnBeforeScenario(CancellationToken token)
        {
            _endGameScreen.RestartBtn.onClick += OnRestartClick;
            return UniTask.CompletedTask;
        }

        protected override void OnScenarioEnd()
        {
            _endGameScreen.RestartBtn.onClick -= OnRestartClick;
        }

        protected override async UniTask RunInternal(CancellationToken token)
        {
            _data.UISystem.GetScreen<GameScreen>().Hide();
            
            if (_data.IsWin)
            {
                _endGameScreen.Data = winScreenData;
            }
            else
            {
                _endGameScreen.Data = loseScreenData;
            }
            
            _endGameScreen.Show();
            _data.GameStateController.SetState<MenuState>();

            await UniTask.WhenAny(UniTask.WaitUntilCanceled(token), UniTask.WaitUntil(() => _isStopped));

            _endGameScreen.Hide();
            _data.UISystem.GetScreen<LoadingScreen>().Show();
            _data.GameStateController.SetState<GameplayState>();
            _data.GameStateController.RestartGame().Forget();
        }
        
        private void OnRestartClick(UIClickableView btn)
        {
            _isStopped = true;
        }
    }
    
    

    public struct EndGameScenarioData : IScenarioData
    {
        public UISystem UISystem;
        public GameStateController GameStateController;
        public bool IsWin;
    }
}