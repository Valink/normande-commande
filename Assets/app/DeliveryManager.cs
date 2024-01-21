using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    [SerializeField] private List<IslandBehaviour> islands;

    private IslandBehaviour destinationIsland;

    public delegate void OnNewDestination(IslandBehaviour island);
    public event OnNewDestination onNewDestination;

    public void Awake()
    {
        ChooseIsland();
    }
    public void ChooseIsland()
    {
        if (destinationIsland != null)
        {
            List<IslandBehaviour> islandsWithoutDestination = new List<IslandBehaviour>(islands);
            islandsWithoutDestination.Remove(destinationIsland);
            destinationIsland = islandsWithoutDestination[Random.Range(0, islandsWithoutDestination.Count)];
        }
        else
        {
            destinationIsland = islands[Random.Range(0, islands.Count)];
        }

        onNewDestination?.Invoke(destinationIsland);
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

    private void CheckIfIslandIsDestinationOne(IslandBehaviour island)
    {
        if (island == destinationIsland)
        {
            Debug.Log($"Bravo ! Tu as livré à {island.cityName}");
            ChooseIsland();
        }
    }
}
