using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    Camera cam;
    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    public void GetZoomInValue(InputAction.CallbackContext context)
    {
        if (context.performed && cam.orthographicSize != 20) cam.orthographicSize += .5f;
    }

    public void GetZoomOutValue(InputAction.CallbackContext context)
    {
        if (context.performed && cam.orthographicSize != .5f) cam.orthographicSize -= .5f;
    }
}
