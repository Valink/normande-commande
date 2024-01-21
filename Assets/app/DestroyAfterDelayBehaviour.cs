using UnityEngine;

public class DestroyAfterDelayBehaviour : MonoBehaviour
{
    public float delayInSeconds = 2f;

    void OnEnable()
    {
        Destroy(gameObject, delayInSeconds);
    }
}