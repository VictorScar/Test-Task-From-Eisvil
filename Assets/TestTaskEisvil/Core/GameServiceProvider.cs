using ScarFramework.UI;
using TestTaskEisvil._Level;
using UnityEngine;

namespace TestTaskEisvil.Core
{
    public class GameServiceProvider
    {
        private ServiceProviderData _data;
        public static GameServiceProvider I { get; private set; }
  
        public GameServiceProvider(ServiceProviderData data)
        {
            _data = data;

            if (GameServiceProvider.I == null)
            {
                GameServiceProvider.I = this;
            }
        }

        public void RegisterLevel(Level level)
        {
            _data.SceneController.CurrentLevel = level;
        }
    }

    public struct ServiceProviderData
    {
        public SceneController SceneController;
        public UISystem UISystem;
    }
}