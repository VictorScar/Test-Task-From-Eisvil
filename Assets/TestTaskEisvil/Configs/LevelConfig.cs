using UnityEngine;

namespace TestTaskEisvil.Configs
{
    [CreateAssetMenu(menuName = "Configs/LevelConfig", fileName = "LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private float maxLoadingTime = 2f;
        

        public float MaxLoadingTime => maxLoadingTime;
    }
}