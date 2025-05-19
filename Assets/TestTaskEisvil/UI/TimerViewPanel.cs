using System;
using ScarFramework.UI;
using TMPro;
using UnityEngine;

namespace TestTaskEisvil.UI
{
    public class TimerViewPanel : UIView
    {
        [SerializeField] private TMP_Text timeLabel;

        public TimeSpan Data
        {
            set => timeLabel.text = value.ToString(@"hh\:mm\:ss");
        }
    }
}
