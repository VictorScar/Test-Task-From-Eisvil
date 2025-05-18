using System;
using UnityEngine;
using UnityEngine.AI;

namespace TestTaskEisvil.Characters._AI._Components
{
    public class AIMover : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        public event Action<bool> onMoving;

        public void MoveTo(Vector3 bodyPosition, float dataMoveSpeed)
        {
            agent.speed = dataMoveSpeed;
            agent.SetDestination(bodyPosition);
            onMoving?.Invoke(true);
        }

        public void StopMove()
        {
            agent.speed = 0f;
            agent.SetDestination(transform.position);
            onMoving?.Invoke(false);
        }

        public void LookAt(Vector3 target, float rotationSpeed)
        {
            agent.transform.rotation =
                Quaternion.LookRotation((target - agent.transform.position).normalized * rotationSpeed * Time.deltaTime);
        }
    }
}