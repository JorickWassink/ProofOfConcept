using UnityEngine;
using UnityEngine.InputSystem;

public class CameraReturn : MonoBehaviour
{
    [SerializeField] GameObject ScriptHolder;
    GameObject targetObject = null;
    public void GetPlayerInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //Instantiate(ScriptHolder, targetObject.transform);
        }
    }
}
