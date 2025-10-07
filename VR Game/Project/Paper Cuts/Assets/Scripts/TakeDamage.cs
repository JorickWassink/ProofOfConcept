using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (ComponentsCheck.HasComponent<Enemy_Script>(collision.gameObject))
        {
            if (EventManager.CheckPlayerDeath()) EventManager.DamageTaken();
            //else //TODO: EndScreen + stop game
        }
    }
}
