using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMover : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    public void MoveTo(Vector3 bodyPosition, float dataMoveSpeed)
    {
        agent.speed = dataMoveSpeed;
        agent.SetDestination(bodyPosition);
    }

    public void StopMove()
    {
        agent.speed = 0f;
        agent.SetDestination(transform.position);
    }
}
