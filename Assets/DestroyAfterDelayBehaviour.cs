using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelayBehaviour : MonoBehaviour
{
    public float delayInSeconds = 2f; // Temps avant de détruire la fumée

    // Start is called before the first frame update
    void Start()
    {
        // Démarrer la coroutine pour détruire la fumée après le temps spécifié
        StartCoroutine(DestroySmoke());
    }

    IEnumerator DestroySmoke()
    {
        // Attendre le temps spécifié
        yield return new WaitForSeconds(delayInSeconds);

        // Détruire la fumée
        Destroy(gameObject);
    }
}