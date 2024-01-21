using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private DeliveryManager deliveryManager;

    [SerializeField] private EnemyBehaviour[] enemyBehaviours;

    public void OnEnable()
    {
        deliveryManager.onNewDestination += OnNewDestination;
    }

    public void OnDisable()
    {
        deliveryManager.onNewDestination -= OnNewDestination;
    }

    public void OnNewDestination(IslandBehaviour island)
    {
        foreach (var enemyBehaviour in enemyBehaviours)
        {
            enemyBehaviour.SetDestination(island);
        }
    }

}
