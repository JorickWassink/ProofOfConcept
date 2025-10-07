using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField] private int enemyHealth = 1;
    private EnemyTypeHandler enemyTypesHandler;
    private ProjectileTypesHandler projectileTypesHandler;

    private void Start()
    {
        enemyTypesHandler = GetComponent<EnemyTypeHandler>();
        projectileTypesHandler = GetComponent<ProjectileTypesHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ProjectileTypesHandler otherTypeHandler = other.GetComponent<ProjectileTypesHandler>();
        if (otherTypeHandler != null)
        {
            Destroy(otherTypeHandler.gameObject);
            if (CanDamage(otherTypeHandler.projectileType))
            {
                Debug.Log(enemyTypesHandler.enemyType + " takes damage from " + otherTypeHandler.projectileType);
                GetDamage();
            }
            else
            {
                Debug.Log(enemyTypesHandler.enemyType + " is NOT damaged by " + otherTypeHandler.projectileType);
            }
        }
    }

    public void GetDamage()
    {
        enemyHealth--;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private bool CanDamage(ProjectileTypes projectileType)
    {
        switch (projectileType)
        {
            case ProjectileTypes.Rock:
                return enemyTypesHandler.enemyType == EnemyTypes.Scissors;
            case ProjectileTypes.Scissors:
                return enemyTypesHandler.enemyType == EnemyTypes.Paper;
            case ProjectileTypes.Paper:
                return enemyTypesHandler.enemyType == EnemyTypes.Rock;
            default:
                return false;
        }
    }
}


