using UnityEngine;

namespace TestTaskEisvil.Characters._AI._Components
{
    public interface IAiTarget : IDamageReceiver
    {
        public Transform Body { get; }
        public bool IsAlive { get; }
    }
}