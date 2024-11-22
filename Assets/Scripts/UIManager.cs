using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas m_gameOverScreen;
    [SerializeField] private Canvas m_playerUI;
    private void OnEnable()
    {
        EventBus.Instance.GameOverEvent.AddListener(TurnOnGameOverScreen);
    }

    private void OnDisable()
    {
        EventBus.Instance.GameOverEvent.RemoveListener(TurnOnGameOverScreen);
    }

    private void TurnOnGameOverScreen()
    {
        m_playerUI.gameObject.SetActive(false);
        m_gameOverScreen.gameObject.SetActive(true);
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
