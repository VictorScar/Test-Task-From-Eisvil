using UnityEngine;

namespace TestTaskEisvil.Configs
{
    [CreateAssetMenu(menuName = "Configs/GameConfig", fileName = "GameConfig")]
    public class GameConfig : ScriptableObject
    {
        [SerializeField] private LevelConfig levelConfig;
        [SerializeField] private PlayerPawnConfig pawnConfig;
        [SerializeField] private NpcConfig npcConfig;
        public LevelConfig LevelConfig => levelConfig;
        public PlayerPawnConfig PawnConfig => pawnConfig;
        public NpcConfig NpcConfig => npcConfig;
    }
}