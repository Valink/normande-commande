using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private IslandBehaviour destination;
    [SerializeField] private bool osef;

    public void Awake()
    {
        SetDestination(destination);
    }

    public void SetDestination(IslandBehaviour island)
    {
        Debug.Log("esgseg");
        destination = island;
        navMeshAgent.SetDestination(destination.transform.position);
    }

    public void Update()
    {
        if (osef)
        {
            SetDestination(destination);
            osef = false;
        }
    }
}
