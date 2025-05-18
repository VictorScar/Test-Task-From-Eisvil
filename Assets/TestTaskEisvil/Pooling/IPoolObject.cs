using System;

namespace TestTaskEisvil.Pooling
{
    public interface IPoolObject
    {
        event Action<IPoolObject> onSpawn;
        event Action<IPoolObject> onDeSpawn;

        void Reset();
        void SetActive(bool enabled);
    }
}