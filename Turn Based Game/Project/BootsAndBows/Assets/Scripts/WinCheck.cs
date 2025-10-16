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

        PlayerInfo[] allPlayers = FindObjectsByType<PlayerInfo>(FindObjectsSortMode.None);

        if (allPlayers.Length == 0)
            return;

        HashSet<int> alivePlayerIDs = new HashSet<int>();
        foreach (PlayerInfo player in allPlayers)
        {
            alivePlayerIDs.Add(player.playerID);
        }

        // Win condition: only one team left
        if (alivePlayerIDs.Count <= 1)
        {
            gameEnded = true;

            int winnerID = allPlayers[0].playerID;
            Debug.Log($"Player {winnerID} wins!");

            // TODO: show message (e.g., UIManager.Instance.ShowVictoryMessage)
        }
    }

    private void LoadEndScene()
    {
        SceneManager.LoadScene(endSceneName);
    }
}
