using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCheck : MonoBehaviour
{
    [SerializeField] private float victoryDelay = 3f;
    [SerializeField] private string endSceneName = "EndScene";

    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded) return;

        PlayerInfo[] allCharacters = FindObjectsByType<PlayerInfo>(FindObjectsSortMode.None);

        if (allCharacters.Length == 0)
            return;

        HashSet<int> alivePlayerIDs = new HashSet<int>();
        foreach (PlayerInfo character in allCharacters)
        {
            alivePlayerIDs.Add(character.playerID);
        }

        if (alivePlayerIDs.Count <= 1)
        {
            gameEnded = true;

            int winnerID = allCharacters[0].playerID;
            Debug.Log($"Player {winnerID} wins!");

            // TODO: Replace with your UI system
            // UIManager.Instance.ShowVictoryMessage($"Player {winnerID} wins!");

            Invoke(nameof(LoadEndScene), victoryDelay);
        }
    }

    private void LoadEndScene()
    {
        SceneManager.LoadScene(endSceneName);
    }
}
