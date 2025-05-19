using UnityEngine;
using UnityEngine.Serialization;

namespace TestTaskEisvil.Configs
{
    [CreateAssetMenu(menuName = "Configs/LevelConfig", fileName = "LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private float maxLoadingTime = 2f;
        [SerializeField] private LevelTasksConfig tasksConfig;
        [SerializeField] private LevelCameraSettings cameraSettings;
        public float MaxLoadingTime => maxLoadingTime;
        public LevelTasksConfig TasksConfig => tasksConfig;
        public LevelCameraSettings CameraSettings => cameraSettings;
    }
}