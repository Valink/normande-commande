using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    public int maxHealth = 100; // Points de vie max
    private int currentHealth; // Points de vie actuels

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; // Au début, les points de vie sont au maximum
    }

    // Méthode pour infliger des dégâts à la cible
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Réduire les points de vie en fonction des dégâts reçus
        Debug.Log(currentHealth);

        // Vérifier si la cible est éliminée
        if (currentHealth <= 0)
        {
            Destroy(gameObject); // Appeler la méthode Die() si les points de vie sont épuisés
        }
        else
        {
            UpdateHealthUI(); // Mettre à jour l'interface utilisateur des points de vie
        }
    }

    // Méthode pour mettre à jour l'interface utilisateur des points de vie (à adapter en fonction de votre mise en page)
    private void UpdateHealthUI()
    {
        // Ajoutez ici le code pour mettre à jour l'interface utilisateur des points de vie
        // Par exemple, vous pouvez afficher les points de vie actuels à l'écran
    }
}
