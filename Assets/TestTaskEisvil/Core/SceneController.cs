using Cysharp.Threading.Tasks;
using TestTaskEisvil._Level;
using TestTaskEisvil.Configs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestTaskEisvil.Core
{
    public class SceneController : MonoBehaviour
    {
        private Level _currentLevel;
        private LevelConfig _config;
        public Level CurrentLevel
        {
            get => _currentLevel;
            set => _currentLevel = value;
        }

        public void Init(LevelConfig config)
        {
            _config = config;
            _currentLevel = null;
        }

        public async UniTask LoadGame()
        {
            var levelLoading = SceneManager.LoadSceneAsync("GameScene");
            await UniTask.WaitUntil(() => levelLoading.isDone);
            await UniTask.WhenAny(UniTask.WaitUntil(() => _currentLevel != null),
                UniTask.WaitForSeconds(_config.MaxLoadingTime));

            if (_currentLevel)
            {
                _currentLevel.Init(new LevelInitData());
            }
            else
            {
                Debug.Log("Level not found!");
            }
        }
    }
}