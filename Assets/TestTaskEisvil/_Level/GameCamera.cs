using UnityEngine;

namespace TestTaskEisvil._Level
{
   public class GameCamera : MonoBehaviour
   {
      [SerializeField] private Camera _camera;
      [SerializeField] private float cameraSpeed = 8f;

      private bool _isStopFollow;
   
      public Vector3 Position
      {
         get { return transform.position; }
         set { transform.position = value; }
      }

      public Quaternion Rotation
      {
         get { return transform.rotation; }
         set { transform.rotation = value; }
      }

      public void SetActive(bool enabled)
      {
         gameObject.SetActive(enabled);
      }
   }
}
