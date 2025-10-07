using System;

//Dit script moet andere scripts met elkaar verbinden zonder errors te veroorzaken door de dependencies.
public class EventManager //deze class is mede mogelijk gemaakt door: https://www.youtube.com/watch?v=gx0Lt4tCDE0 en OpenAI
{
    public static event Action OnTakeDamage;
    public static void DamageTaken() => OnTakeDamage?.Invoke();


    public static event Action OnKill;
    public static void Kill() => OnKill?.Invoke();


    public static event Action OnNewWave;
    public static void NewWave() => OnNewWave?.Invoke();


    public static event Action<float> OnScore;
    public static void Score(float score) => OnScore?.Invoke(score);


    public static event Action OnGameEnd;
    public static void EndGame() => OnGameEnd?.Invoke();


    public static event Func<bool> OnPlayerDeathCheck;
    public static bool CheckPlayerDeath() {
        if (OnPlayerDeathCheck != null) return OnPlayerDeathCheck.Invoke();
        return true;
    }
}
