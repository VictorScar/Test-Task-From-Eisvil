using UnityEngine;

namespace TestTaskEisvil.Configs
{
    [CreateAssetMenu(menuName = "Configs/Level/CameraSettings", fileName = "LevelCameraSettings")]
    public class LevelCameraSettings : ScriptableObject
    {
        [SerializeField] private float startCameraSpeed = 10f;
        [SerializeField] private float startCameraOffset = 12f;
        [SerializeField] private float cameraFollowSpeed = 5f;

        public float StartCamersSpeed => startCameraSpeed;
        public float StartCameraOffset => startCameraOffset;
        public float CameraFollowSpeed => cameraFollowSpeed;



    }
}
