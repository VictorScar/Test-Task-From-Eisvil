using System;
using ScarFramework.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestTaskEisvil.UI
{
    public class EndGameScreen : UIScreen
    {
        [Header("References")]
        [SerializeField] private TMP_Text header;
        [SerializeField] private TMP_Text description;
        [SerializeField] private Image bg;
        [SerializeField] private Color winColor;
        [SerializeField] private Color loseColor;
        [SerializeField] private UIClickableView restartBtn;

        public UIClickableView RestartBtn => restartBtn;

        public EndGameScreenData Data
        {
            set
            {
                header.text = value.Header;
                description.text = value.Description;
                IsWin = value.IsWin;
            }
        }

        private bool IsWin
        {
            set
            {
                var bgColor = value? bg.color = winColor : bg.color = loseColor;
                bg.color = bgColor;
            }
        }
    }

    [Serializable]
    public struct EndGameScreenData
    {
        public bool IsWin;
        public string Header;
        public string Description;
    }
}
