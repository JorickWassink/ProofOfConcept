using UnityEngine;

public class ProjectileTypesHandler : MonoBehaviour
{
    [SerializeField] public ProjectileTypes projectileType;
}
public enum ProjectileTypes//enum waarmee je de projectileType kunt kiezen / zetten.
{
    Rock,
    Paper,
    Scissors
}