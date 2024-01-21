using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class DeliveryManager : MonoBehaviour
{
    [SerializeField] private List<IslandBehaviour> islands;

    [SerializeField] private EnemyBehaviour[] enemyBehaviours;

    public IslandBehaviour destinationIsland;

    [SerializeField] private TextMeshProUGUI DestinationText;

    public int camenbertCount;

    public delegate void OnDelivery(int camenbertCount, GameObject other);
    public event OnDelivery onDelivery;

    public delegate void OnNewDestination(IslandBehaviour island);
    public event OnNewDestination onNewDestination;

    public delegate void OnDestinationIsland(IslandBehaviour island);
    public event OnDestinationIsland onDestinationIsland;

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

        DestinationText.text = destinationIsland.cityName;    

        PickRandomNumberOfCamenbert();

        SetEnemiesDestination();

        onNewDestination?.Invoke(destinationIsland);
        onDestinationIsland?.Invoke(destinationIsland);
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

    private void CheckIfIslandIsDestinationOne(IslandBehaviour island, GameObject other)
    {
        if (island == destinationIsland)
        {
            onDelivery?.Invoke(camenbertCount, other);
            ChooseIsland();
        }
    }
}
