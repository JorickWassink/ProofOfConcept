
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    [SerializeField] GameObject menus;
    Enemy_Spawn eS;

    private void Start()
    {
        eS = FindAnyObjectByType<Enemy_Spawn>();
    }

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
        menus.SetActive(false);
        foreach (var enemy in eS.enemies)
        {
            enemy.SetActive(true);
        }
    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            menus.SetActive(true);
            foreach(var enemy in eS.enemies)
            {
                enemy.SetActive(false);
            }
        }
    }
}
