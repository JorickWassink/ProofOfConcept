using System.IO;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshPro hp, waves, scoreUI, kills, hSWaves, hSScore, hSKills;
    [SerializeField] PlayerStats stats;
    [SerializeField] int HP;


    [SerializeField] string file = "HighScore.json";
    private void Start()
    {
        EventManager.OnTakeDamage += TakeDamage;//voeg de funktie toe aan OnTakeDamage die gecalled word als de OnTakeDamage variabele invoked word
        EventManager.OnPlayerDeathCheck += DeathCheck;
        EventManager.OnKill += Kill;
        EventManager.OnNewWave += NewWave;
        EventManager.OnScore += AddScores;
        EventManager.OnGameEnd += EndGame;

        ResetStats();
    }
    public void Kill() => stats.Kills++;
    public void NewWave() => stats.Waves++;
    public void AddScores(float score) => stats.Scores += score;
    public bool DeathCheck() => HP > 0;
    public void TakeDamage()
    {
        HP--;

        if(hp != null) hp.text = HP.ToString();
        else Debug.LogError("hp not assigned");
    }
    public void EndGame()
    {
        PlayerStats highScores =  GetHighScore();

        UpdateHighScore(stats, highScores);
        SaveHighScore(highScores);

        ShowHighScoreStats(highScores);
        ShowRunStats();

    }
    private PlayerStats GetHighScore()
    {
        if (File.Exists(file))
        {
            string json = File.ReadAllText(file);
            return JsonUtility.FromJson<PlayerStats>(json);
        }
        else return new PlayerStats() { Kills = 0, Scores = 0, Waves = 0 };
    }
    private void UpdateHighScore(PlayerStats runScore, PlayerStats HighScore)
    {
        if (HighScore.Kills < runScore.Kills) HighScore.Kills = runScore.Kills;
        if (HighScore.Scores < runScore.Scores) HighScore.Scores = runScore.Scores;
        if (HighScore.Waves < runScore.Waves) HighScore.Waves = runScore.Waves;
    }
    private void SaveHighScore(PlayerStats highScore)
    {
        string json = JsonUtility.ToJson(highScore);
        File.WriteAllText(file, json);
    }
    private void ShowRunStats()
    {
        if (kills != null) kills.text = stats.Kills.ToString();
        else Debug.LogError("killls not assigned");

        if (waves != null) waves.text = stats.Waves.ToString();
        else Debug.LogError("waves not assigned");

        if (scoreUI != null) scoreUI.text = stats.Scores.ToString();
        else Debug.LogError("scoreUI not assigned");
    }
    private void ShowHighScoreStats(PlayerStats highScore)
    {
        if (hSKills != null) hSKills.text = highScore.Kills.ToString();
        else Debug.LogError("hSKillls not assigned");

        if (hSWaves != null) hSWaves.text = highScore.Waves.ToString();
        else Debug.LogError("hSWaves not assigned");

        if (hSScore != null) hSScore.text = highScore.Scores.ToString();
        else Debug.LogError("hSScore not assigned");
    }

    private void ResetStats()
    {
        stats = new PlayerStats()
        {
            Scores = 0,
            Waves = 1,
            Kills = 0
        };
        HP = 3;
    }
}