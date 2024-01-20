using UnityEngine;
using UnityEngine.Events;

public class IslandBehaviour : MonoBehaviour
{
    [SerializeField] public string cityName;
    [SerializeField] private TMPro.TextMeshProUGUI cityNameText;

    public delegate void OnBoatEnter(IslandBehaviour island);
    public event OnBoatEnter onBoatEnter;

    public void Awake()
    {
        cityNameText.text = cityName;
    }

    public void OnTriggerEnter(Collider other)
    {
        onBoatEnter?.Invoke(this);
    }
}
