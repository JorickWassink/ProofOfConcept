using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 movementDirection;
    float speed = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = movementDirection * speed;
    }


    public void GetMoveInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            movementDirection = context.ReadValue<Vector2>();
        }
        else
        {
            movementDirection = Vector2.zero;
        }
    }
}
