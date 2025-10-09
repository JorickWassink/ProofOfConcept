using UnityEngine;

public class EnemyTypeHandler : MonoBehaviour
{
    [SerializeField] public EnemyTypes enemyType;
}
public enum EnemyTypes//enum voor de EnemyTypes waarmee je kunt instellen welke type de enemy is.
{
    Rock,
    Paper,
    Scissors
}