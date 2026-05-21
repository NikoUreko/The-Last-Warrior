using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public GameObject continueButton;

   void Start()
{
    if (PlayerPrefs.HasKey("LastLevelIndex"))
        continueButton.SetActive(true);
    else
        continueButton.SetActive(false);
}

   public void ContinueGame()
    {
        if (GameManager.Instance != null &&
            GameManager.Instance.playerHealth <= 0)
        {
            GameManager.Instance.ResetPlayerHealth();
        }
        if (PlayerPrefs.HasKey("LastLevelIndex"))
        {
            int lastLevelIndex = PlayerPrefs.GetInt("LastLevelIndex");

            // Cegah error jika index lebih besar dari jumlah scene
            if (lastLevelIndex < SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(lastLevelIndex);
            else
                SceneManager.LoadScene(1); // atau Level1 jika melebihi index
        }
        else
        {
            SceneManager.LoadScene(1); // Level1
        }
    }

   public void Level1()
   {
    PlayerPrefs.DeleteKey("LastLevelIndex");
    if (GameManager.Instance != null)
    {
        GameManager.Instance.ResetPlayerHealth();
    }
    SceneManager.LoadScene("Level1");
   }

   public void Level2()
   {
    PlayerPrefs.DeleteKey("LastLevelIndex");
    if (GameManager.Instance != null)
    {
        GameManager.Instance.ResetPlayerHealth();
    }
    SceneManager.LoadScene("Level2");
   }

   public void Level3()
   {
    PlayerPrefs.DeleteKey("LastLevelIndex");
    if (GameManager.Instance != null)
    {
        GameManager.Instance.ResetPlayerHealth();
    }
    SceneManager.LoadScene("Level3");
   }
   public void Quit()
   {
        Application.Quit();
        Debug.Log("The game has quit");
   }
}
