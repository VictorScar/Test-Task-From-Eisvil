using System;
using TestTaskEisvil._Level.LevelTasks;
using TestTaskEisvil.Characters._AI;
using UnityEngine;

namespace TestTaskEisvil._Level
{
    [CreateAssetMenu(menuName = "Configs/Level/Tasks/DefaultTask", fileName = "DefaultTask")]
    public class LevelTaskData : ScriptableObject
    {
        public string Description;
        public int RequiredValue;
        public TaskTargetID TaskID;
        public EnemyID TargetID;
    }
}