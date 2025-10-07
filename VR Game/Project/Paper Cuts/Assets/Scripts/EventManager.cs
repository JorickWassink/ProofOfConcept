using System;
using UnityEngine;

public class EventManager : MonoBehaviour //deze class is mede mogelijk gemaakt door: https://www.youtube.com/watch?v=gx0Lt4tCDE0 en OpenAI
{
    public static event Action OnTakeDamage;
    public static void DamageTaken() => OnTakeDamage?.Invoke();

    public static event Func<bool> OnPlayerDeathCheck;
    public static bool CheckPlayerDeath() {
        if (OnPlayerDeathCheck != null) return OnPlayerDeathCheck.Invoke();
        return true;
    }
}
