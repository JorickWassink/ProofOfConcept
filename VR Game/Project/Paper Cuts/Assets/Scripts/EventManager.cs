using System;

//Dit script moet andere scripts met elkaar verbinden zonder errors te veroorzaken door de dependencies.
public class EventManager //deze class is mede mogelijk gemaakt door: https://www.youtube.com/watch?v=gx0Lt4tCDE0 en OpenAI
{
    public static event Action OnTakeDamage;// in dit custom event worden funkties toegevoegd die vervolgens allemaal in 1 keer gerund kan worden over meerdere scriptjes
    public static void DamageTaken() => OnTakeDamage?.Invoke();//deze funktie is vanuit iedere script te bereiken wat mogelijk maakt dat alle funkties in de OnTakeDamage variabele worden gecalled als de OnTakeDamage tenminste niet leeg is


    public static event Action OnKill;
    public static void Kill() => OnKill?.Invoke();


    public static event Action OnNewWave;
    public static void NewWave() => OnNewWave?.Invoke();


    public static event Action<float> OnScore; //hier is er dankzij de <> mogelijk om data mee te geven aan alle gecallde funkties
    public static void Score(float score) => OnScore?.Invoke(score);


    public static event Action OnGameEnd;
    public static void EndGame() => OnGameEnd?.Invoke();


    public static event Func<bool> OnPlayerDeathCheck;// aangezien Action geen waarde terug kan sturen  word Func gebruikt. Een func verwacht wel 1 antwoord terug en kan dus niet meerdere funkties aansturen
    public static bool CheckPlayerDeath() => OnPlayerDeathCheck?.Invoke() ?? false;// indien de OnPlayerDeathCkeck leeg is word er altijd true terug gestuurd naar de gebruiker.
}
