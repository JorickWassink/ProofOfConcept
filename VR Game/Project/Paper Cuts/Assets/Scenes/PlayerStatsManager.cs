using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    [SerializeField] PlayerStats stats;
    [SerializeField] int HP;
    private void Start() => ResetStats();
    public void Kill() {
        stats.Kills++;
        //TODO: update the kills ui
    }
    public void NewWave() {
        stats.Waves++;
        //TODO: update the waves ui
    }
    public void AddScores(float score) {
        stats.Scores+= score;
        //TODO: update the score ui
    }

    public void Damage() {
        HP--;
        //TODO: update the HitPoints ui
    }

    public void EndGame() {
        //TODO: store stats to JSON
        //TODO: show high score
        //TODO: show run score
        ResetStats();
    }

    private void ResetStats() {
        stats = new() {
            Scores = 0,
            Waves = 1,
            Kills = 0
        };
        HP = 3;
    }
}