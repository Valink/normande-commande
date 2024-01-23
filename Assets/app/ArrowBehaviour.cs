using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    [SerializeField] private DeliveryManager deliveryManager;

    void Update()
    {
        LookAtTarget(deliveryManager.destinationIsland);
    }

    public void OnEnable()
    {
        deliveryManager.onNewDestination += LookAtTarget;
    }

    public void OnDisable()
    {
        deliveryManager.onNewDestination -= LookAtTarget;
    }

    private void LookAtTarget(IslandBehaviour island)
    {
        var directionToTarget = island.transform.position - transform.position;
        var rotationToTarget = Quaternion.LookRotation(directionToTarget);
        transform.rotation = rotationToTarget;
    }
}
