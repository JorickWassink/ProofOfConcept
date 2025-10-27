using UnityEngine;
using UnityEngine.InputSystem;

public class SpringFunction : MonoBehaviour
{
    Transform springTransform;
    Transform OriginalTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        springTransform = gameObject.transform;
        OriginalTransform = springTransform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void CheckPlayerInput(InputAction.CallbackContext context)
    {
        
    }
}
