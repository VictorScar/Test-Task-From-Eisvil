using System;
using ScarFramework.UI;
using TestTaskEisvil.Core;
using UnityEngine;

namespace TestTaskEisvil._Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private PlayerSpawnPoint playerSpawn;

        private LevelInitData _initData;

        private void Start()
        {
            GameServiceProvider.I.RegisterLevel(this);
        }

        public void Init(LevelInitData initData)
        {
            _initData = initData;
            Debug.Log("Level Init");
        }
    }

    public struct LevelInitData
    {
        public UISystem UISystem;
    }
}
