using UnityEngine;
using UnityEngine.UI;

public class MainMenuMusicManager : MonoBehaviour
{
    public Toggle musicToggle;
    private AudioSource musicSource;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();

        // Cek player preference dan set toggle
        bool isMusicOn = PlayerPrefs.GetInt("MusicOn", 1) == 1;
        musicToggle.isOn = isMusicOn;
        musicSource.mute = !isMusicOn;

        // Tambahkan listener ke toggle
        musicToggle.onValueChanged.AddListener(delegate {
            ToggleMusic(musicToggle.isOn);
        });
    }

    public void ToggleMusic(bool isOn)
    {
        musicSource.mute = !isOn;
        PlayerPrefs.SetInt("MusicOn", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
