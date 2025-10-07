using UnityEngine;

public class EnemyTypeHandler : MonoBehaviour
{
    [SerializeField] public EnemyTypes enemyType;
}
public enum EnemyTypes
{
    Rock,
    Paper,
    Scissors
}