using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void OnSettingsClick()
    {
        settingsMenu.SetActive(true);
    }
    public void OnBackClick()
    {
        settingsMenu.SetActive(false);
    }
    public void OnQuitClick()
    {
        Application.Quit();
    }
}
