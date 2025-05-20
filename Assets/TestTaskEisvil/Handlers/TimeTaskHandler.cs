using System;
using TestTaskEisvil._Level;
using TestTaskEisvil.UI;
using UnityEngine;

namespace TestTaskEisvil.Handlers
{
    public class TimeTaskHandler : LevelTaskHandler
    {
        private int _requiredValue;
        private string _description;
        private LevelTimer _levelTimer;

        private bool _requiredTimeIsMinutes;

        public TimeTaskHandler(TimeTaskHandlerData data)
        {
            _requiredValue = data.RequiredValue;

            if (_requiredValue > 60)
            {
                _requiredValue = Mathf.FloorToInt(_requiredValue / 60);
                _requiredTimeIsMinutes = true;
            }
            _description = data.Description;
            _levelTimer = data.LevelTimer;
            _taskView = data.TaskView;

            _taskView.Data = new TaskViewData
            {
                IsCompleted = _isDone,
                Description = _description,
                RequiredValue = _requiredValue
            };
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
            var totalTime = _levelTimer.GetTotalSeconds();

            if (_requiredTimeIsMinutes)
            {
                totalTime = Mathf.FloorToInt(totalTime / 60);
            }

            _currentValue = totalTime;

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