using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int TotalScore;

    [SerializeField] private int ScoreCount;
    [SerializeField] private DeliveryManager deliveryManager;

    public TMPro.TextMeshProUGUI ScoreText;

    public void Awake()
    {
        ScoreText.text = $"Score: {TotalScore}";
    }

    public void OnEnable()
    {
        deliveryManager.onDelivery += ScoreUp;
    }

    public void ScoreUp(DeliveryManager deliveryManager)
    {
        TotalScore += ScoreCount * deliveryManager.CamenbertCount;
        ScoreText.text = $"Score: {TotalScore}";
        Debug.Log($"Score: {TotalScore}");
    }

}
