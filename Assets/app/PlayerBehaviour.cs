using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine.InputSystem;  // Add this line for the Task class

public class PlayerBehaviour : MonoBehaviour
{
    public delegate void OnDie();
    public event OnDie onDie;

    public List<CanonBehaviour> canonsBehaviour;
    public List<EnemyBehaviour> enemiesBehaviour;
    public bool shoot;

    [SerializeField] private InputActionReference shootAction;

    [SerializeField] private HealthManager healthManager;

    public void OnEnable()
    {
        healthManager.onHealthChange += CheckIfDead;
        shootAction.action.performed += (context) => Shoot();
    }

    public void OnDisable()
    {
        healthManager.onHealthChange -= CheckIfDead;
        shootAction.action.performed -= (context) => Shoot();
    }

    void Update()
    {
        if (shoot)
        {
            Shoot();
            shoot = false;
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        var eb = collider.gameObject.GetComponent<EnemyBehaviour>();
        if (eb)
        {
            enemiesBehaviour.Add(eb);
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        var eb = collider.gameObject.GetComponent<EnemyBehaviour>();
        if (eb)
        {
            enemiesBehaviour.Remove(eb);
        }
    }

    public void Shoot()
    {
        enemiesBehaviour = enemiesBehaviour.FindAll(eb => eb != null);

        foreach (var canonBehaviour in canonsBehaviour)
        {
            enemiesBehaviour = enemiesBehaviour.FindAll(eb => eb != null);

            if (enemiesBehaviour.Count > 0)
            {
                var target = enemiesBehaviour[0].transform;
                canonBehaviour.SetTarget(target);
            }

            canonBehaviour.Shoot();
        }
    }

    private async void CheckIfDead(float healthBetween0And1)
    {
        if (healthBetween0And1 <= 0)
        {
            GetComponent<Collider>().enabled = false;
            await Task.Delay(3000);
            onDie?.Invoke();
        }
    }
}
