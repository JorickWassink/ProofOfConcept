using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    BaseCharacter character;
    //THIS SCRIPT SHOULD BE INACTIVE ON THE CHARACTERS UNTILL A CHARACTER CHOOSES TO ATTACK, THEN ITLL ACTIVATE ON THAT CHARACTER
    [SerializeField] private LayerMask Playerlayer;
    [SerializeField] private LayerMask Obstaclelayer;
    public Camera cam;
    public float attackRange = 5f;

    private void Start()
    {
        if (cam == null)
            cam = Camera.main;

        character = gameObject.GetComponent<BaseCharacter>();
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
            Debug.Log("what fuck");
            //inhoud en bijgehorende custom funkties en variabelen zijn door Daniël Geschreven i.v.m. kennen van de scripten en hoe die samen kunnen/moeten werken
            BaseCharacter enemy = playerHit.collider.gameObject.GetComponent<BaseCharacter>();
            enemy.TakeDamage(enemy.facing, character.DoDamage(enemy.facing));
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
