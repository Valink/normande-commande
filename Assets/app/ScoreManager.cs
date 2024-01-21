using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private DeliveryManager deliveryManager;
    [SerializeField] private TextMeshProUGUI ScoreText;
    private int score;

    public void OnEnable()
    {
        deliveryManager.onDelivery += ScoreUp;
    }

    public void OnDisable()
    {
        deliveryManager.onDelivery -= ScoreUp;
    }

    public void ScoreUp(int points)
    {
        score += points;
        ScoreText.text = score.ToString();
    }
}
