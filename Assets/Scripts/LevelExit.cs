using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private bool allEnemiesDefeated;

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        allEnemiesDefeated = enemies.Length == 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && allEnemiesDefeated)
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

            // Simpan index level berikutnya
            PlayerPrefs.SetInt("LastLevelIndex", nextSceneIndex);
            PlayerPrefs.Save();

            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
