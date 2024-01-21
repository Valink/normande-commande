using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private HealthManager healthManager;

    public void OnEnable()
    {
        healthManager.onHealthChange += CheckIfDead;
    }

    public void OnDisable()
    {
        healthManager.onHealthChange -= CheckIfDead;
    }

    public void CheckIfDead(float healthBetween0And1){
        if (healthBetween0And1 <= 0)
        {
            GetComponent<Collider>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            Destroy(gameObject, 3f);
        }
    }

    public void SetDestination(Vector3 targetPosition)
    {
        navMeshAgent.SetDestination(targetPosition);
    }
}
