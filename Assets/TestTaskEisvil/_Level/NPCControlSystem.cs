using System;
using System.Collections.Generic;
using TestTaskEisvil.Characters._AI;
using TestTaskEisvil.Configs;
using TestTaskEisvil.Pooling;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TestTaskEisvil._Level
{
    public class NPCControlSystem : MonoBehaviour
    {
        [SerializeField] private Nest[] nests;
        [SerializeField] private int npcPoolCount = 10;

        private List<NestHandler> _nestHandlers = new List<NestHandler>();
        private Level _level;
        private NpcConfig _npcConfig;
        private LevelObjectsPool<Monster> _monstersPool;
        private List<Monster> spawnedMonsters = new List<Monster>();

        public event Action<EnemyAI> onMonsterDying;

        public void Init(Level level, NpcConfig npcConfig)
        {
            _level = level;
            _npcConfig = npcConfig;

            nests = level.GetComponentsInChildren<Nest>();

            if (nests != null && nests.Length > 0)
            {
                foreach (var nest in nests)
                {
                    nest.Init(npcConfig.NestData);
                    var handler = new NestHandler(nest, npcConfig.MinSpawnTime, npcConfig.SpawnTimeSpread);
                    handler.onSpawn += SpawnMonster;
                    handler.onDie += RemoveNestHandler;
                    _nestHandlers.Add(handler);
                }

                CreateMonstersPool();
            }
        }

        public void SpawnMonster(Transform spawnPoint)
        {
            var monsterID = GetRandomID();
            SpawnMonsterByID(spawnPoint, monsterID);
   }

     

        public void SpawnMonsterByID(Transform parent, EnemyID id)
        {
            if (_monstersPool.GetPoolObject((m) => m.ID == id, out var monster))
            {
               SpawnMonsterInternal(monster, parent);
            }
        }

        private void SpawnMonsterInternal(Monster monster, Transform spawnPoint)
        {
            monster.transform.position = spawnPoint.position;
            monster.transform.rotation = spawnPoint.rotation;
            monster.SetActive(true);
            monster.onDie += OnNpcDying;
            monster.onDeSpawn += OnDespawnNPC;
            spawnedMonsters.Add(monster);
            monster.OnSpawn();
        }

        private void CreateMonstersPool()
        {
            _monstersPool = new LevelObjectsPool<Monster>(transform);

            foreach (var monsterConfig in _npcConfig.MonsterConfigs)
            {
                for (int i = 0; i < npcPoolCount; i++)
                {
                    CreateMonster(monsterConfig);
                }
            }
        }
        
        private EnemyID GetRandomID()
        {
            var randomIndex = Random.Range(0, _npcConfig.MonsterConfigs.Length);
            return _npcConfig.MonsterConfigs[randomIndex].Prefab.ID;
        }

        private void Update()
        {
            if (_nestHandlers != null)
            {
                for (int i = _nestHandlers.Count - 1; i >= 0; i--)
                {
                    _nestHandlers[i].UpdateHandler(Time.deltaTime);
                }
            }
        }

        private void CreateMonster(MonsterConfig monsterConfig)
        {
            var monster = Instantiate(monsterConfig.Prefab, transform);
            monster.Init(monsterConfig.Data, _level);
            monster.SetActive(false);
            _monstersPool.AddObjectInPool(monster);
        }


        private void OnNpcDying(EnemyAI enemy)
        {
            onMonsterDying?.Invoke(enemy);
            enemy.onDie -= OnNpcDying;
            Debug.Log($"NPC ID {enemy.ID} Dying!");
        }

        private void OnDespawnNPC(IPoolObject poolObject)
        {
            poolObject.onDeSpawn -= OnDespawnNPC;
            var monster = poolObject as Monster;
            _monstersPool.ReturnInPool(monster);
            spawnedMonsters.Remove(monster);
        }
        
        private void RemoveNestHandler(NestHandler handler)
        {
            Debug.Log("Remove Handler!");
            handler.onSpawn -= SpawnMonster;
           // handler.onDie -= RemoveNestHandler;
            OnNpcDying(handler.Nest);
            handler.Dispose();
            _nestHandlers.Remove(handler);
        }

        private void OnDestroy()
        {
            if (spawnedMonsters != null)
            {
                foreach (var spawnedMonster in spawnedMonsters)
                {
                    spawnedMonster.onDeSpawn -= OnDespawnNPC;
                    spawnedMonster.onDie -= OnNpcDying;
                }
            }
        }
    }

    public class NestHandler
    {
        private Nest _nest;
        private float _minSpawnTime;
        private float _lastSpawnTime;
        private float _timeSpread;

        private bool _isDisposed;

        public event Action<Transform> onSpawn; 
        public event Action<NestHandler> onDie; 
        
        public NestHandler(Nest nest, float minSpawnTime, float timeSpread)
        {
            _nest = nest;
            _minSpawnTime = minSpawnTime;
            _timeSpread = timeSpread;
            _nest.onDie += OnDie;
            _lastSpawnTime = Random.Range(_minSpawnTime, _minSpawnTime + _timeSpread);
        }

        public EnemyAI Nest => _nest;

        public void UpdateHandler(float deltaTime)
        {
            if(_isDisposed) return;
            
            if (_lastSpawnTime > 0)
            {
                _lastSpawnTime -= deltaTime;
            }
            else
            {
                OnSpawn();
            }
        }

        public void Dispose()
        {
            if (_nest)
            {
                _nest.onDie -= OnDie;
            }

            _isDisposed = true;
        }
        
        private void OnDie(EnemyAI nest)
        {
            nest.onDie -= OnDie;
            onDie?.Invoke(this);
        }



        private void OnSpawn()
        {
            onSpawn?.Invoke(_nest.GetSpawnPoint());
            _lastSpawnTime = Random.Range(_minSpawnTime, _minSpawnTime + _timeSpread);
        }
    }
}