using UnityEngine;

namespace TestTaskEisvil.Characters._AI
{
    public class Nest : EnemyAI
    {
        [SerializeField] private HealthController healthController;
        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private float defaultSpawnOffset;
        
        public Transform GetSpawnPoint()
        {
            if (spawnPoints != null)
            {
                var spawnPointNumber = Random.Range(0, spawnPoints.Length);
                return spawnPoints[spawnPointNumber];
            }

            return null;
        }

        public override void Reset()
        {
           
        }
    }

    public struct EnemySpawnData
    {
        
    }
}
