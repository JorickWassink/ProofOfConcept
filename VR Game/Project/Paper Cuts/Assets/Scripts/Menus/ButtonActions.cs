using TMPro.EditorUtilities;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    [SerializeField] GameObject menus;

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit game");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("MainMenu_Scene");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        menus.SetActive(true);
    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Time.timeScale = 0f;
            menus.SetActive(true);
        }
    }
}
