using ScarFramework.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestTaskEisvil.UI
{
    public class TaskView : UIView
    {
        [SerializeField] private TMP_Text descriptionLabel;
        [SerializeField] private TMP_Text currentValueLabel;
        [SerializeField] private TMP_Text requiredValueLabel;
        [SerializeField] private Image bg;
        [SerializeField] private Image bg2;
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color completeColor;

        public TaskViewData Data
        {
            set
            {
                descriptionLabel.text = value.Description;
                RequireValue = value.RequiredValue;
                CurrentValue = value.CurrentValue;
                IsCompleted = value.IsCompleted;

            }
        }

        public bool IsCompleted
        {
            set
            {
                if (value)
                {
                    bg.color = completeColor;
                    bg2.color = completeColor;
                }
                else
                {
                    bg.color = defaultColor;
                    bg2.color = defaultColor;
                }
            }
        }

        public int CurrentValue
        {
            set => currentValueLabel.text = value.ToString();
        }

        public int RequireValue
        {
            set => requiredValueLabel.text = $"/{value}";
        }
    }
}
