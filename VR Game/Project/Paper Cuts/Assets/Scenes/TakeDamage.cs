using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    [SerializeField] int HP = 3;
    private void OnCollisionEnter(Collision collision)
    {
        if (ComponentsCheck.HasComponent<Enemy_Script>(collision.gameObject))
        {
            HP--;
            //als er een ander centrale plek is voor de HP kan dat hier verbeterd worden
        }
    }
}
