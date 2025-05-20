using TestTaskEisvil.UI;
using UnityEngine;

namespace TestTaskEisvil.Handlers
{
    public abstract class LevelTaskHandler
    {
        protected TaskView _taskView;
        protected int _currentValue;
        protected bool _isDone;
        public bool IsDone => _isDone;

        public virtual void UpdateHandler(float deltaTime)
        {
        }

        public void Dispose()
        {
            OnDispose();

            if (_taskView)
            {
                Object.Destroy(_taskView.gameObject);
            }
        }

        protected virtual void OnDispose()
        {
        }

        protected void UpdateView()
        {
            _taskView.CurrentValue = _currentValue;
            _taskView.IsCompleted = _isDone;
        }
    }
}