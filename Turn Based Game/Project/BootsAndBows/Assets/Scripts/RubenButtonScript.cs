using UnityEngine;
using UnityEngine.SceneManagement;

public class RubenButtonScript : MonoBehaviour
{
    [Header("Optional UI References")]
    public GameObject settingsCanvas;

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

        //Extra code kan voor als je de game wilt blijven runnen of niet wanneer settings wordt geklikt
    }
}
