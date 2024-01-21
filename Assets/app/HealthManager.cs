using UnityEngine;
using UnityEngine.AI;

public class HealthManager : MonoBehaviour
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

        onHealthChange?.Invoke((float)currentHealth / maxHealth);
    }
}
