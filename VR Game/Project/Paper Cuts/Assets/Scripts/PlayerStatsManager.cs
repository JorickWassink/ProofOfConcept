using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshPro hp, waves, scoreUI, kills, HSWaves, HSScore, HSKills;
    [SerializeField] PlayerStats stats;
    [SerializeField] int HP;
    private void Start()
    {
        EventManager.OnTakeDamage += TakeDamage;
        EventManager.OnPlayerDeathCheck += DeathCheck;
        ResetStats();
    }
    public void Kill() => stats.Kills++;
    public void NewWave() => stats.Waves++;
    public void AddScores(float score) => stats.Scores += score;
    public bool DeathCheck() => HP <= 0;
    public void TakeDamage()
    {
        HP--;
        hp.text = HP.ToString();
    }
    public void EndGame()
    {
        //TODO: store stats to JSON
        ShowHighScoreStats();
        ShowRunStats();
        ResetStats();
    }
    private void ShowRunStats()
    {
        kills.text = stats.Kills.ToString();
        waves.text = stats.Waves.ToString();
        scoreUI.text = stats.Scores.ToString();
    }
    private void ShowHighScoreStats(PlayerStats HighScore)
    {
        HSKills.text = stats.Kills.ToString();
        HSWaves.text = stats.Waves.ToString();
        HSScore.text = stats.Scores.ToString();
    }

    private void ResetStats()
    {
        stats = new()
        {
            Scores = 0,
            Waves = 1,
            Kills = 0
        };
        HP = 3;
    }
}