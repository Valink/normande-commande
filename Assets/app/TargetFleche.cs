using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TargetFleche : MonoBehaviour
{
    [SerializeField] private DeliveryManager deliveryManager;
    void Update()
    {
        LookAtTarget(deliveryManager.destinationIsland);
    }

    public void OnEnable()
    {
        deliveryManager.onDestinationIsland += LookAtTarget;
    }

    public void OnDisable()
    {
        deliveryManager.onDestinationIsland -= LookAtTarget;
    }

    private void LookAtTarget(IslandBehaviour island)
    {
        var directionToTarget = island.transform.position - transform.position;
        var rotationToTarget = Quaternion.LookRotation(directionToTarget);
        transform.rotation = rotationToTarget;
    }
}
