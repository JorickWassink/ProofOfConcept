using System.Net.Mime;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpringFunction : MonoBehaviour
{
    Transform springTransform;
    Transform OriginalTransform;
    bool pressed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        springTransform = gameObject.transform;
        OriginalTransform = springTransform;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed)
        {
            transform.localScale = Vector2.Lerp(OriginalTransform.localScale.x,);
        }
    }


    public void CheckPlayerInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            pressed = true;
        }
        else
        {
            pressed = false;
        }
    }
}
