using UnityEngine;

namespace TestTaskEisvil.Scenarios
{
    public class ScenariosContainer : MonoBehaviour
    {
        [SerializeField] private ScenarioBase[] scenarios;

        public T GetScenario<T>() where T : ScenarioBase
        {
            if (scenarios != null)
            {
                foreach (var scenario in scenarios)
                {
                    if (scenario is T typedScenario)
                    {
                        return typedScenario;
                    }
                }
            }

            return null;
        }
    }
}