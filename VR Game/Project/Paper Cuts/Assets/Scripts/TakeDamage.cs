using UnityEngine;
using UnityEngine.SceneManagement;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] GameObject endScreen;
    EnemyWavesSystem eWS;

    private void Start()
    {
        eWS = FindAnyObjectByType<EnemyWavesSystem>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (ComponentsCheck.HasComponent<NavMeshMovement>(collision.gameObject))
        {
            if (EventManager.CheckPlayerDeath())
            {
                EventManager.DamageTaken();
                Destroy(collision.gameObject);
                eWS.EnemyDied();
            }
            else
            {
                EventManager.EndGame();
                SceneManager.LoadScene("MainMenu_Scene");
            }
        }
    }
}
