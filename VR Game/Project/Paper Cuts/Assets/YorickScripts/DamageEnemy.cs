using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    [SerializeField] private int enemyHealth = 1;//int voor de enemies health
    private EnemyTypeHandler enemyTypesHandler;//maakt een instantie van de EnemyTypesHandler

    private void Start()
    {
        enemyTypesHandler = GetComponent<EnemyTypeHandler>();//pakt het EnemyTypesHandler component
    }
    private void OnTriggerEnter(Collider other)
    {
        ProjectileTypesHandler otherTypeHandler = other.GetComponent<ProjectileTypesHandler>();//maakt een instantie van de projectileTypesHandler en pakt het component met dezelfde naam.
        if (otherTypeHandler != null)//checkt of het object null is.
        {
            Destroy(otherTypeHandler.gameObject);//destroyed het object
            if (CanDamage(otherTypeHandler.projectileType))//checkt of de projectile kan damagen (als projectile schaar is en enemy papier dan doet die damage. anders niet.)
            {
                Debug.Log(enemyTypesHandler.enemyType + " takes damage from " + otherTypeHandler.projectileType);
                GetDamage();//roept de GetDamage method op
            }
            else
            {
                Debug.Log(enemyTypesHandler.enemyType + " is NOT damaged by " + otherTypeHandler.projectileType);
            }
        }
    }
    public void GetDamage()//verlaagt de Health van de enemy en kijkt of het al dood is/ gekilled is.
    {
        enemyHealth--;
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            FindAnyObjectByType<EnemyWavesSystem>().EnemyDied();
        }
    }
    private bool CanDamage(ProjectileTypes projectileType)//hier wordt gechecked of de projectile de enemy kan damagen
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


