using System.Threading.Tasks;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public HealthBarControllerBehaviours healthBar;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log(currentHealth);

        healthBar.UpdateHealthBar(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            Destroy(gameObject, 1f);
        }
    }
}
