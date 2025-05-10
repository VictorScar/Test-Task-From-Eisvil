using UnityEngine;

namespace TestTaskEisvil.Configs
{
    [CreateAssetMenu(menuName = "Configs/GameConfig", fileName = "GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private LevelConfig levelConfig;

        public LevelConfig LevelConfig => levelConfig;
    }
}