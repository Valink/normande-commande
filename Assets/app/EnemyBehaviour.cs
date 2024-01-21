using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;

    public void SetDestination(Vector3 targetPosition)
    {
        navMeshAgent.SetDestination(targetPosition);
    }
}
