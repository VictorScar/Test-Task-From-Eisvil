using ScarFramework.UI;
using UnityEngine;

namespace TestTaskEisvil.UI
{
    public class GameScreen : UIScreen
    {
        [Space(3)]
        [Header("References")]
        [SerializeField] private TaskPanel taskPanel;
        [SerializeField] private TimerViewPanel timeIndicator;
        [SerializeField] private HeroInfoPanel heroInfoPanel;
        [SerializeField] private HintPanel hintPanel;

        public TaskPanel TaskPanel => taskPanel;
        public TimerViewPanel TimeIndicator => timeIndicator;
        public HeroInfoPanel HeroInfoPanel => heroInfoPanel;
        public HintPanel HintPanel => hintPanel;

        protected override void OnInit()
        {
            taskPanel.Init();
            timeIndicator.Init();
            heroInfoPanel.Init();
            hintPanel.Init();
        }
    }
}
