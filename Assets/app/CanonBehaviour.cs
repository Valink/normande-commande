using UnityEngine;

public class CanonBehaviour : MonoBehaviour
{
    [SerializeField] private int reach = 100;
    [SerializeField] private int damage = 35;
    public Transform target;
    public GameObject smokePrefab;
    public GameObject ballPrefab;
    public GameObject explosionPrefab;
    public Transform smokesContainer;
    public Transform ballsContainer;
    public Transform explosionsContainer;
    public bool shoot;

    void Update()
    {
        if (target)
        {
            LookAtTarget();
        }

        if (shoot)
        {
            Shoot();
            shoot = false;
        }
    }

    private void LookAtTarget()
    {
        var directionToTarget = target.position - transform.position;
        var rotationToTarget = Quaternion.LookRotation(directionToTarget);
        transform.rotation = rotationToTarget;
    }

    private void Shoot()
    {
        Instantiate(smokePrefab, smokesContainer);
        Instantiate(ballPrefab, ballsContainer);

        if (Physics.Raycast(transform.position, transform.forward, out var hit, reach))
        {
            var explosion = Instantiate(explosionPrefab, explosionsContainer);
            explosion.transform.position = hit.transform.position;

            var target = hit.transform.GetComponentInParent<HealthManager>();

            if (target)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
