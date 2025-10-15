using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCheck : MonoBehaviour
{
    [SerializeField] private float victoryDelay = 3f;         // Delay before switching scenes
    [SerializeField] private string endSceneName = "EndScene"; // Scene to load on victory

    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded) return;

        // Find all remaining characters that have the Attack component
        Attack[] allCharacters = FindObjectsByType<Attack>(FindObjectsSortMode.None);

        // If there are no characters left, nothing to check yet
        if (allCharacters.Length == 0)
            return;

        // Track which players are still alive
        HashSet<int> alivePlayerIDs = new HashSet<int>();

        foreach (Attack character in allCharacters)
        {
            // Make sure the Attack script has a valid playerID
            // (You’ll replace this once your spawn system guarantees it)
            alivePlayerIDs.Add(character.playerID);
        }

        // Check win condition: only one unique playerID left
        if (alivePlayerIDs.Count <= 1)
        {
            gameEnded = true;

            int winnerID = allCharacters[0].playerID;
            Debug.Log($"Player {winnerID} wins!");

            // TODO: Hook this up to your actual UI system when ready
            // UIManager.Instance.ShowVictoryMessage($"Player {winnerID} wins!");

            Invoke(nameof(LoadEndScene), victoryDelay);
        }
    }

    private void LoadEndScene()
    {
        SceneManager.LoadScene(endSceneName);
    }
}
