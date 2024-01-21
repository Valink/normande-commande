using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarControllerBehaviours : MonoBehaviour
{
    public Image healthBarFill; // Référence à l'élément de remplissage de la barre de vie
    public float fillSpeed = 0.5f; // Vitesse de remplissage de la barre de vie

    private void Start()
    {
        // Assurez-vous que healthBarFill est correctement configuré dans l'éditeur Unity
        if (healthBarFill == null)
        {
            Debug.LogError("Health Bar Fill Image not assigned in the inspector!");
        }
    }

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        float fillAmount = (float)currentHealth / maxHealth;
        healthBarFill.transform.localScale = new Vector3(fillAmount,1,1);
        //StartCoroutine(LerpFillAmount(fillAmount));
    }

    private IEnumerator LerpFillAmount(float targetFill)
    {
        float currentFill = healthBarFill.fillAmount;
        float elapsedTime = 0f;

        while (elapsedTime < fillSpeed)
        {
            healthBarFill.fillAmount = Mathf.Lerp(currentFill, targetFill, elapsedTime / fillSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        healthBarFill.fillAmount = targetFill;
    }
}
