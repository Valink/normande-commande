using UnityEngine;
using UnityEngine.AI;

public class TargetBehaviour : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public delegate void OnHealthChange(float healthBetween0And1);
    public event OnHealthChange onHealthChange;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            GetComponent<Collider>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            Destroy(gameObject, 3f);
        }

        onHealthChange?.Invoke((float)currentHealth / maxHealth);
    }
}
