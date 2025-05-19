using System;
using TestTaskEisvil._Level;
using TestTaskEisvil.UI;
using Object = UnityEngine.Object;

namespace TestTaskEisvil.Handlers
{
    public class TimeTaskHandler : LevelTaskHandler
    {
        private int _requiredValue;
        private string _description;
        private LevelTimer _levelTimer;

        public TimeTaskHandler(TimeTaskHandlerData data)
        {
            _requiredValue = data.RequiredValue;
            _description = data.Description;
            _levelTimer = data.LevelTimer;
            _taskView = data.TaskView;
            Handle();
        }

        protected override void OnDispose()
        {
            if (_levelTimer)
            {
                _levelTimer.onTimeChanged -= OnTimeChanged;
            }
        }

        private void Handle()
        {
            _levelTimer.onTimeChanged += OnTimeChanged;
            _taskView.Data = new TaskViewData
            {
                Description = _description,
                RequiredValue = _requiredValue,
                CurrentValue = _currentValue,
                IsCompleted = _isDone
            };
        }

        private void OnTimeChanged(TimeSpan time)
        {
            _currentValue = _levelTimer.GetTotalSeconds();

            if (_currentValue >= _requiredValue)
            {
                _isDone = true;
                _levelTimer.onTimeChanged -= OnTimeChanged;
            }

            UpdateView();
        }
    }

    public struct TimeTaskHandlerData
    {
        public LevelTimer LevelTimer;
        public TaskView TaskView;
        public int RequiredValue;
        public string Description;
    }
}