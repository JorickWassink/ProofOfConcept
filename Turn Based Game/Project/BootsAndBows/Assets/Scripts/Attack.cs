using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    public event Func<Facing, float> attack;
    public event Func<Facing> facing;
    public event Action<Facing, float> damage;


    //THIS SCRIPT SHOULD BE INACTIVE ON THE CHARACTERS UNTILL A CHARACTER CHOOSES TO ATTACK, THEN ITLL ACTIVATE ON THAT CHARACTER
    [SerializeField] private LayerMask Playerlayer;
    [SerializeField] private LayerMask Obstaclelayer;
    public Camera cam;
    public float attackRange = 5f;


    public Facing GetFacing() => facing?.Invoke() ?? Facing.None;
    public void TakeDamage(float damageTaking) => damage?.Invoke(GetFacing(), damageTaking);
    private void Start()
    {
        if (cam == null)
            cam = Camera.main;

    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            HandleAttackClick();
        }
    }

     private void HandleAttackClick()
    {
        Debug.Log("pew");

        // Get mouse position in screen space and convert to world space
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 worldPos = cam.ScreenToWorldPoint(mousePos);

        // Flatten Z so it stays on the 2D plane
        worldPos.z = 0f;

        // Draw for debugging
        Debug.DrawLine(transform.position, worldPos, Color.red, 0.5f);

        // Direction from player to click point
        Vector2 direction = (worldPos - transform.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, attackRange, Obstaclelayer);
        RaycastHit2D playerHit = Physics2D.Raycast(transform.position, direction, attackRange, Playerlayer);
        if (hit.collider != null)
        {
             Debug.Log($"Hit: {hit.collider.name}"); 
        }
        else if (playerHit.collider != null)
        {
            //inhoud en bijgehorende custom funkties en variabelen zijn door Daniël Geschreven i.v.m. kennen van de scripten en hoe die samen kunnen/moeten werken
            Attack enemy = playerHit.collider.gameObject.GetComponent<Attack>();
            float damage = (float)attack?.Invoke(enemy.GetFacing());
            enemy.TakeDamage(damage);
        }
        else
        {
            Debug.Log("complete miss or out of range");
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
