using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    [SerializeField] private List<IslandBehaviour> islands;

    [SerializeField] private EnemyBehaviour[] enemyBehaviours;

    [SerializeField] private IslandBehaviour destinationIsland;
    public int camenbertCount;

    public delegate void OnDelivery(int camenbertCount);
    public event OnDelivery onDelivery;

    public delegate void OnNewDestination(IslandBehaviour island);
    public event OnNewDestination onNewDestination;

    public void Awake()
    {
        ChooseIsland(); // TODO gameManager should call this
    }

    public void OnEnable()
    {
        foreach (var island in islands)
        {
            island.onBoatEnter += CheckIfIslandIsDestinationOne;
        }
    }

    public void OnDisable()
    {
        foreach (var island in islands)
        {
            island.onBoatEnter -= CheckIfIslandIsDestinationOne;
        }
    }

    public void ChooseIsland()
    {
        if (destinationIsland != null)
        {
            var islandsWithoutDestination = new List<IslandBehaviour>(islands);
            islandsWithoutDestination.Remove(destinationIsland);
            destinationIsland = PickARandomIslandIn(islandsWithoutDestination);
        }
        else
        {
            destinationIsland = PickARandomIslandIn(islands);
        }

        PickRandomNumberOfCamenbert();
        SetEnemiesDestination();

        onNewDestination?.Invoke(destinationIsland);
    }

    private void SetEnemiesDestination()
    {
        foreach (var enemyBehaviour in enemyBehaviours)
        {
            enemyBehaviour.SetDestination(destinationIsland.transform.position);
        }
    }

    private IslandBehaviour PickARandomIslandIn(List<IslandBehaviour> islands)
    {
        return this.islands[Random.Range(0, this.islands.Count)];
    }

    private void PickRandomNumberOfCamenbert()
    {
        camenbertCount = Random.Range(100, 500);
    }

    private void CheckIfIslandIsDestinationOne(IslandBehaviour island)
    {
        if (island == destinationIsland)
        {
            onDelivery?.Invoke(camenbertCount);
            ChooseIsland();
        }
    }
}
