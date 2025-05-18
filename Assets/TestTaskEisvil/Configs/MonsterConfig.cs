using TestTaskEisvil.Characters._AI;
using UnityEngine;

namespace TestTaskEisvil.Configs
{
    [CreateAssetMenu(menuName = "Configs/NPC/Monsters", fileName = "MonsterConfig")]
    public class MonsterConfig : ScriptableObject
    {
        [SerializeField] private Monster prefab;
        [SerializeField] private MonsterData data;
    
        public Monster Prefab => prefab;
        public MonsterData Data => data;
    }
}
