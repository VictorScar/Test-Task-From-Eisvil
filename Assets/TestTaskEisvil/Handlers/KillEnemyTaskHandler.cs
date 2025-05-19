using TestTaskEisvil._Level;
using TestTaskEisvil.Characters._AI;
using TestTaskEisvil.UI;
using UnityEngine;

namespace TestTaskEisvil.Handlers
{
    public class KillEnemyTaskHandler : LevelTaskHandler
    {
        private EnemyID _targetID;
        private int _requiredValue;
        private string _description;
        private NPCControlSystem _npcControlSystem;

        public KillEnemyTaskHandler(KillEnemyTaskData data)
        {
            _targetID = data.TargetID;
            _requiredValue = data.RequiredValue;
            _description = data.Description;
            _npcControlSystem = data.NpcControlSystem;
            _taskView = data.TaskView;
            Handle();
        }

        protected override void OnDispose()
        {
            _npcControlSystem.onMonsterDying -= OnKill;
        }

        private void Handle()
        {
            _npcControlSystem.onMonsterDying += OnKill;
            _taskView.Data = new TaskViewData
            {
                Description = _description,
                RequiredValue = _requiredValue,
                CurrentValue = _currentValue,
                IsCompleted = _isDone
            };
        }

        private void OnKill(EnemyAI enemy)
        {
            if (_targetID == EnemyID.All || enemy.ID == _targetID)
            {
                _currentValue++;

                if (_currentValue >= _requiredValue)
                {
                    _isDone = true;
                    _npcControlSystem.onMonsterDying -= OnKill;
                }

                UpdateView();
            }
        }
    }

    public struct KillEnemyTaskData
    {
        public EnemyID TargetID;
        public int RequiredValue;
        public string Description;
        public NPCControlSystem NpcControlSystem;
        public TaskView TaskView;
    }
}