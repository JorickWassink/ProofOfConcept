[System.Serializable]//System.Serializable zorgt er voor dat unity niet gaat zeuren over de struct
public struct PlayerStats
{
    public int Kills {  get; set; }
    public int Waves { get; set; }
    public float Scores { get; set; }
}
