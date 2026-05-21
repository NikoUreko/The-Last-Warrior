using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float playerHealth = 100f;

 public void ResetPlayerHealth()
{
    playerHealth = 100f;
}
    void Awake()
    {
        // Cek agar hanya ada satu GameManager di semua scene
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Simpan GameManager saat pindah scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
