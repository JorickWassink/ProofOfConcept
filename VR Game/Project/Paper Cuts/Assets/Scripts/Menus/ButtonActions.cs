using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit game");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
