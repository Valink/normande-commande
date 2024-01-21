using UnityEngine;
using System.Threading.Tasks;  // Add this line for the Task class

public class PlayerBehaviour : MonoBehaviour
{
    public delegate void OnDie();
    public event OnDie onDie;

    [SerializeField] private HealthManager healthManager;

    public void OnEnable()
    {
        healthManager.onHealthChange += CheckIfDead;
    }

    public void OnDisable()
    {
        healthManager.onHealthChange -= CheckIfDead;
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
