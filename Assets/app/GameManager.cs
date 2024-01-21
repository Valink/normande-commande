using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private DeliveryManager deliveryManager;
    [SerializeField] private PlayerBehaviour playerBehaviour;

    public void OnEnable()
    {
        playerBehaviour.onDie += QuitGame;
    }

    public void OnDisable()
    {
        playerBehaviour.onDie -= QuitGame;
    }

    private void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
