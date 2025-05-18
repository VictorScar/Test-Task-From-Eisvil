using System;
using System.Collections.Generic;
using TestTaskEisvil.Pooling;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TestTaskEisvil
{
    public class LevelObjectsPool<T> where T : MonoBehaviour, IPoolObject
    {
        private List<T> _poolObjects = new List<T>();
        private Transform _parent;

        public LevelObjectsPool(Transform parent)
        {
            _parent = parent;
        }

        public void AddObjectInPool(T obj)
        {
            _poolObjects.Add(obj);
        }

        public bool GetPoolObject(out T poolObject)
        {
            for (int i = _poolObjects.Count - 1; i >= 0; i--)
            {
                var obj = _poolObjects[i];


                poolObject = obj;
                _poolObjects.Remove(obj);
                return true;
            }

            poolObject = null;
            return false;
        }

        public bool GetPoolObject(Predicate<T> condition, out T poolObject)
        {
            for (int i = _poolObjects.Count - 1; i >= 0; i--)
            {
                var obj = _poolObjects[i];

                if (condition(obj))
                {
                    poolObject = obj;
                    _poolObjects.Remove(obj);
                    return true;
                }
            }

            poolObject = null;
            return false;
        }

        public void ReturnInPool(T obj)
        {
            obj.SetActive(false);
            obj.Reset();
            _poolObjects.Add(obj);
        }

        public void Clear()
        {
            if (_poolObjects != null)
            {
                for (var i = _poolObjects.Count - 1; i >= 0; i--)
                {
                    var poolObject = _poolObjects[i];

                    if (poolObject != null)
                    {
                        _poolObjects.Remove(poolObject);
                        Object.Destroy(poolObject.gameObject);
                    }
                }
            }
        }
    }
}