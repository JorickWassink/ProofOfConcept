using UnityEngine;

public class MatchResultManager : MonoBehaviour
{
    public static MatchResultManager Instance { get; private set; }

    public int WinningPlayerID { get; private set; }

    private void Awake()
    {
        // Make this persist between scenes
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetWinner(int playerID)
    {
        WinningPlayerID = playerID;
    }
}
