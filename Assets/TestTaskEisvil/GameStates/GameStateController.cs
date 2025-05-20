using Cysharp.Threading.Tasks;
using TestTaskEisvil.GameStates;
using UnityEngine;

namespace TestTaskEisvil.Core
{
    public class GameStateController : MonoBehaviour
    {
        private GameStateBase[] _states;
        private GameStateBase _currentState;
        private LevelController _levelController;

        public void Init(LevelController levelController)
        {
            _levelController = levelController;
            
            _states = new GameStateBase[]
            {
                new GameplayState(),
                new MenuState(),
            };
        }
        
        public void SetState<T>() where T: GameStateBase
        {
            foreach (var state in _states)
            {
                if (state is T typedState)
                {
                    if (_currentState != null)
                    {
                        _currentState.Exit();
                    }

                    _currentState = state;
                    _currentState.Enter();
                }
            }
        }

        public async UniTask RestartGame()
        {
            await _levelController.LoadGame();
        }
    }
}
