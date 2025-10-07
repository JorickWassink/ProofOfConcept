using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] GameObject endScreen;
    private void OnCollisionEnter(Collision collision)
    {
        if (ComponentsCheck.HasComponent<NavMeshMovement>(collision.gameObject))
        {
            if (EventManager.CheckPlayerDeath())
            {
                EventManager.DamageTaken();
                collision.gameObject.SetActive(false);
            }
            else
            {
                EventManager.EndGame();
                if (endScreen != null) endScreen.SetActive(true);
                else Debug.LogError("endScreen not assigned");
            }
        }
    }
}
