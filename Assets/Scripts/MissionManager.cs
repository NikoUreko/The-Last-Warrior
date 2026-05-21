using UnityEngine;
using TMPro; // Jika pakai TextMeshPro

public class MissionManager : MonoBehaviour
{
    public static MissionManager Instance;
    public TextMeshProUGUI missionText;
    public string initialMission = "Kalahkan semua musuh";
    public string completeMission = "Jalan ke ujung stage, untuk melanjutkan ke Level berikutnya";

    private bool missionUpdated = false;

    public bool missionCompleted = false;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        missionText.text = initialMission;
    }

    void Update()
    {
        // Cek apakah semua musuh sudah dikalahkan
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0 && !missionUpdated)
        {
            missionText.text = completeMission;
            missionUpdated = true;
            missionCompleted = true;
        }
    }
}
