using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    [SerializeField] private List<IslandBehaviour> islands;

    private IslandBehaviour destinationIsland;

    public void Awake()
    {
        ChoiceIsland();
    }
    public void ChoiceIsland()
    {
        if (destinationIsland != null)
        {
            List<IslandBehaviour> islandsWithoutDestination = new List<IslandBehaviour>(islands);

            islandsWithoutDestination.Remove(destinationIsland);
            destinationIsland = islandsWithoutDestination[Random.Range(0, islandsWithoutDestination.Count)];
            Debug.Log($"ChoiceIsland: {destinationIsland.cityName}");
        }
        else
        {
            destinationIsland = islands[Random.Range(0, islands.Count)];
            Debug.Log($"ChoiceIsland: {destinationIsland.cityName}");
        }
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
            ChoiceIsland();
        }
    }
}
