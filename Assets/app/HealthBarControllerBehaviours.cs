using UnityEngine;
using UnityEngine.UI;

public class HealthBarControllerBehaviours : MonoBehaviour
{
    public TargetBehaviour targetBehaviour;
    public Image healthBarFiller;

    public void OnEnable()
    {
        targetBehaviour.onHealthChange += UpdateHealthBar;
    }

    public void OnDisable()
    {
        targetBehaviour.onHealthChange -= UpdateHealthBar;
    }

    public void UpdateHealthBar(float healthBetween0And1)
    {
        healthBarFiller.transform.localScale = new Vector3(healthBetween0And1, 1, 1);
    }
}
