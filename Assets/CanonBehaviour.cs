using System.Collections;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CanonBehaviour : MonoBehaviour
{
    public Transform target; // Référence vers la cible (cube)
    public GameObject smokePrefab;
    public GameObject ballPrefab;  
    public GameObject explosionPrefab; 
    public Transform smokesContainer; 
    public Transform ballsContainer; 
    public Transform explosionsContainer; 
    public bool shoot;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    async void Update()
    {
        
        // Voir la trajectoire
        Debug.DrawRay(transform.position, transform.forward * 15, Color.red);

        if (target != null)
        {
            // Calcul de la direction vers la cible
            Vector3 directionToTarget = target.position - transform.position;

            // Calcul de la rotation pour faire face à la cible
            Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);

            // Appliquer la rotation au canon
            transform.rotation = rotationToTarget;
        }

        if(shoot){
            Instantiate(smokePrefab, smokesContainer);
            Instantiate(ballPrefab, ballsContainer);

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
            {
                var explosion = Instantiate(explosionPrefab, explosionsContainer);
                explosion.transform.position = hit.transform.position;

                // Obtenez le composant TargetBehaviour de l'objet touché
                TargetBehaviour target = hit.transform.GetComponentInParent<TargetBehaviour>();

                Debug.Log(target);
                Debug.Log(hit.transform.gameObject);

                if (target != null)
                {
                    // Infliger un tiers des dégâts à la cible
                    int damageAmount = +35;
                    target.TakeDamage(damageAmount, hit);
                }
            }

            shoot = false;
        }
    }
}
