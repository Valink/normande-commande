using UnityEngine;
using UnityEngine.UI;

public class HealthBarControllerBehaviours : MonoBehaviour
{
    public HealthManager healthManager;
    public Image healthBarFiller;

    public void OnEnable()
    {
        healthManager.onHealthChange += UpdateHealthBar;
    }

    public void OnDisable()
    {
        healthManager.onHealthChange -= UpdateHealthBar;
    }

    public void UpdateHealthBar(float healthBetween0And1)
    {
        healthBarFiller.transform.localScale = new Vector3(healthBetween0And1, 1, 1);
    }
}
