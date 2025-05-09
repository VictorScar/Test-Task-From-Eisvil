using UnityEngine;

namespace TestTaskEisvil._Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private PlayerSpawnPoint playerSpawn;

        public void Init(LevelInitData initData)
        {
            
        }
    }

    public struct LevelInitData
    {
        
    }
}
