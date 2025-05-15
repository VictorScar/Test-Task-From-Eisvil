using UnityEngine;

namespace TestTaskEisvil._Level
{
    public class CameraFollow : MonoBehaviour
    {
        private GameCamera _camera;
        private Transform _target;
        
        public void Init(GameCamera camera, Transform target)
        {
            _camera = camera;
            _target = target;
        }

        // Update is called once per frame
        void Update()
        {
            if (_target)
            {
                
            }
        }
    }
}
