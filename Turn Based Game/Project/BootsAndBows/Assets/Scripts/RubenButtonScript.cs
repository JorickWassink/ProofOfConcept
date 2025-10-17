using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RubenButtonScript : MonoBehaviour
{
    [Header("Optional UI References")]
    public GameObject settingsCanvas;
    public Slider musicSlider;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

        if (musicSlider != null)
        {
            musicSlider.minValue = 0f;
            musicSlider.maxValue = 1f;
            musicSlider.onValueChanged.AddListener(UpdateMusicVolume);
            UpdateMusicVolume(musicSlider.value);
        }
    }

    private void UpdateMusicVolume(float value)
    {
        if (audioManager != null && audioManager.audioSource != null)
        {
            audioManager.audioSource.volume = Mathf.Pow(value, 2f);
        }
    }

    public void LoadLevel(string p = "")
    {
        SceneManager.LoadScene(p);
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void Settings()
    {
        if (settingsCanvas == null)
        {
            Debug.LogWarning("Oops");
            return;
        }

        bool isActive = settingsCanvas.activeSelf;
        settingsCanvas.SetActive(!isActive);
    }
}
