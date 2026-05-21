using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    public static WinManager Instance;
    public GameObject winPanel;
    public AudioSource winAudioSource; 

    public bool gameWon = false;
    
    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (!gameWon && AreAllEnemiesDefeated())
        {
            WinGame();
        }
    }

    bool AreAllEnemiesDefeated()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return enemies.Length == 0;
    }

    void WinGame()
    {
        gameWon = true;
        Time.timeScale = 0f; // Freeze game
        winPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Play sound
        if (winAudioSource != null)
        {
            winAudioSource.Play();
        }
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
