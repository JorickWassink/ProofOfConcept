using TMPro;
using UnityEngine;

public class GameOver: MonoBehaviour
{
    [SerializeField] private TMP_Text winnerText;

    private void Start()
    {
        if (MatchResultManager.Instance != null)
        {
            int winnerID = MatchResultManager.Instance.WinningPlayerID;
            winnerText.text = $"Player {winnerID} now rules the land";
        }
    }
}
