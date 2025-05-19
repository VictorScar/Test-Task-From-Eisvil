using TestTaskEisvil._Level;
using UnityEngine;

namespace TestTaskEisvil.Configs
{
    [CreateAssetMenu(menuName = "Configs/Level/TasksConfig", fileName = "LevelTaskConfig")]
    public class LevelTasksConfig : ScriptableObject
    {
        [SerializeField] private LevelTaskData[] tasks;

        public LevelTaskData[] Tasks => tasks;
    }
}
