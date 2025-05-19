using ScarFramework.UI;
using UnityEngine;

namespace TestTaskEisvil.UI
{
    public class TaskPanel : UIView
    {
        [SerializeField] private RectTransform viewsContainer;
        
        public TaskPanelData Data
        {
            set
            {
                foreach (var data in value.ViewDatas)
                {
                    var taskView = Instantiate(data.ViewPrefab, viewsContainer);
                    taskView.Data = data;
                }
            }
        }
    }

    public struct TaskPanelData
    {
        public TaskViewData[] ViewDatas;
    }

    public struct TaskViewData
    {
        public string Description;
        public int RequiredValue;
        public int CurrentValue;
        public TaskView ViewPrefab;
        public bool IsCompleted;
    }
    
}