using UnityEngine;

namespace TestTaskEisvil.Configs
{
    [CreateAssetMenu(menuName = "Configs/NPCConfig", fileName = "NPCConfig")]
    public class NpcConfig : ScriptableObject
    {
        [SerializeField] private MonsterConfig[] monstersConfigs;
        [SerializeField] private float minSpawnTime;
        [SerializeField] private float spawnTimeSpread;
        public MonsterConfig[] MonsterConfigs => monstersConfigs;
        public float MinSpawnTime => minSpawnTime;
        public float SpawnTimeSpread => spawnTimeSpread;
    }
}
