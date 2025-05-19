using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using ScarFramework.UI;
using TestTaskEisvil._Level;
using TestTaskEisvil._Level.LevelTasks;
using TestTaskEisvil.Configs;
using TestTaskEisvil.Handlers;
using TestTaskEisvil.UI;

namespace TestTaskEisvil.Scenarios
{
    public class LevelTaskScenario : GameScenario<LevelTaskScenarioData>
    {
        private LevelTimer _levelTimer;
        private NPCControlSystem _npcControlSystem;
        private TaskPanel _taskPanel;

        private List<LevelTaskHandler> _taskHandlers = new List<LevelTaskHandler>();

        protected override void OnInit(LevelTaskScenarioData data)
        {
            _levelTimer = data.Level.LevelTimer;
            _npcControlSystem = _data.Level.NpcControlSystem;
            _taskPanel = _data.UISystem.GetScreen<GameScreen>().TaskPanel;
        }

        protected override async UniTask RunInternal(CancellationToken token)
        {
            CreateHandlers();

            await UniTask.WhenAny(UniTask.WaitUntilCanceled(token),
                UniTask.WaitUntil(IsAllTaskCompleted, cancellationToken: token));
        }

        protected override void OnScenarioEnd()
        {
            if (_taskHandlers != null)
            {
                foreach (var handler in _taskHandlers)
                {
                    handler.Dispose();
                }
                
                _taskHandlers.Clear();
            }
        }

        private void CreateHandlers()
        {
            var tasksDatas = _data.TasksConfig.Tasks;

            if (tasksDatas != null)
            {
                foreach (var data in tasksDatas)
                {
                    var handler = GetHandler(data);
                    _taskHandlers.Add(handler);
                }
            }
        }

        private LevelTaskHandler GetHandler(LevelTaskData taskData)
        {
            if (TryCreateKillTaskHandler(taskData, out var killHandler))
            {
                return killHandler;
            }

            if (TryCreateTimeTaskHandler(taskData, out var timeHandler))
            {
                return timeHandler;
            }

            return null;
        }

        private bool TryCreateKillTaskHandler(LevelTaskData taskData, out KillEnemyTaskHandler handler)
        {
            if (taskData.TaskID == TaskTargetID.Kill)
            {
                var taskView = _taskPanel.CreateTaskView();
                handler = new KillEnemyTaskHandler(new KillEnemyTaskData
                {
                    Description = taskData.Description,
                    RequiredValue = taskData.RequiredValue,
                    TargetID = taskData.TargetID,
                    NpcControlSystem = _npcControlSystem,
                    TaskView = taskView
                });

                return true;
            }

            handler = null;
            return false;
        }
        
        private bool TryCreateTimeTaskHandler(LevelTaskData taskData, out TimeTaskHandler handler)
        {
            if (taskData.TaskID == TaskTargetID.Time)
            {
                var taskView = _taskPanel.CreateTaskView();
                handler = new TimeTaskHandler(new TimeTaskHandlerData
                {
                    Description = taskData.Description,
                    RequiredValue = taskData.RequiredValue,
                    LevelTimer = _levelTimer,
                    TaskView = taskView
                });

                return true;
            }

            handler = null;
            return false;
        }

        public bool IsAllTaskCompleted()
        {
            var isCompleted = true;

            foreach (var handler in _taskHandlers)
            {
                if (!handler.IsDone)
                {
                    isCompleted = false;
                   break;
                }
            }

            return isCompleted;
        }
    }

    public struct LevelTaskScenarioData : IScenarioData
    {
        public UISystem UISystem;
        public Level Level;
        public LevelTasksConfig TasksConfig;
    }
}