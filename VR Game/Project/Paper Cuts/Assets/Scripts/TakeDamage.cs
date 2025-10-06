using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    PlayerStatsManager playerStats;

    private void Start() => playerStats = GetComponent<PlayerStatsManager>();
    private void OnCollisionEnter(Collision collision)
    {
        if (ComponentsCheck.HasComponent<Enemy_Script>(collision.gameObject)) playerStats.Damage();
    }
}
