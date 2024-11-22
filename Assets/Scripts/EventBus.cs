using UnityEngine;
using UnityEngine.Events;

public class EventBus : MonoBehaviour
{
    public UnityEvent GameOverEvent;
    public bool isGameOver { get; private set; }
    public static EventBus Instance;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

    }
    public void GameOver()
    {
        if (isGameOver == false)
        {
            isGameOver = true;
            GameOverEvent?.Invoke();
        }
    }
}
