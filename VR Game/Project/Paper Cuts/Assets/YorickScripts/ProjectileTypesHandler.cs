using UnityEngine;

public class ProjectileTypesHandler : MonoBehaviour
{
    [SerializeField] public ProjectileTypes projectileType;
}
public enum ProjectileTypes
{
    Rock,
    Paper,
    Scissors
}