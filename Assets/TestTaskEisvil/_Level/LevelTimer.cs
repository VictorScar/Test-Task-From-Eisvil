using System;
using UnityEngine;

namespace TestTaskEisvil._Level
{
    public class LevelTimer : MonoBehaviour
    {
        private float _rawCurrentTime;
        private bool _isStarted;
        private int _seconds;
        private int _minutes;
        private int _hours;

        public event Action<TimeSpan> onTimeChanged;
        public event Action onTimerIsStarted;
        public event Action onTimerIsStopped;

        public int Seconds => _seconds;

        public int Minutes => _minutes;

        public int Hours => _hours;
        public bool IsStarted => _isStarted;

        public TimeSpan FormattedTime => new(_hours, _minutes, _seconds);

        private void Update()
        {
            if (_isStarted)
            {
                _rawCurrentTime += Time.deltaTime;
                UpdateTime();
            }
        }

        public void StartTimer()
        {
            _rawCurrentTime = 0f;
            _isStarted = true;
            onTimerIsStarted?.Invoke();
        }

        private void UpdateTime()
        {
            var seconds = Mathf.FloorToInt(_rawCurrentTime);
            var minutes = Mathf.FloorToInt(seconds / 60);
            var hours = Mathf.FloorToInt(minutes / 60);

            if (seconds != _seconds || minutes != _minutes || hours != _hours)
            {
                onTimeChanged?.Invoke(new TimeSpan(hours, minutes, seconds));
            }

            _seconds = seconds;
            _minutes = minutes;
            _hours = hours;
        }

        public void Stop()
        {
            _isStarted = false;
            onTimerIsStopped?.Invoke();
        }

        public void ResetTimer()
        {
            _seconds = 0;
            _minutes = 0;
            _hours = 0;

            onTimeChanged?.Invoke(new TimeSpan(_hours, _minutes, _seconds));
        }

        public int GetTotalSeconds()
        {
            return _hours * 60 * 60 + _minutes * 60 + _seconds;
        }
    }
}