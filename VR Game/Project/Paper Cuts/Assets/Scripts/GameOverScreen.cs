using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    private void OnEnable()//stop game
    {
        Time.timeScale = 0.0f;
        gameObject.SetActive(true);
    }
    public void DisableUI()//run game
    {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }
}
