using System.Threading;
using Cysharp.Threading.Tasks;
using ScarFramework.UI;
using TestTaskEisvil.UI;
using UnityEngine;

namespace TestTaskEisvil.Scenarios
{
    public class HintScenario : GameScenario<HintScenarioData>
    {
        [SerializeField] private float showHintDuration = 5f;
        private HintPanel _hintPanel;
        protected override void OnInit(HintScenarioData data)
        {
            _hintPanel = _data.UISystem.GetScreen<GameScreen>().HintPanel;
        }

        protected override async UniTask RunInternal(CancellationToken token)
        {
            _hintPanel.Show();
            await UniTask.WaitForSeconds(showHintDuration, cancellationToken: token);
            _hintPanel.Hide();
        }
    }

    public struct HintScenarioData: IScenarioData
    {
        public UISystem UISystem;
       }
}