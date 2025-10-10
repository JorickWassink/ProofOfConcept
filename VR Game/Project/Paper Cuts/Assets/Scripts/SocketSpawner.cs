using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor))]
public class SocketSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject weaponPrefab;

    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;
    private UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable currentWeapon;

    Transform playerHead;

    void Start()
    {
        socket = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();
        playerHead = Camera.main.transform;

        // Listen for when something is removed
        socket.selectExited.AddListener(OnItemRemoved);

        SpawnWeapon();
    }

    void LateUpdate()
    {
        // Make holster rotate with player yaw
        if (playerHead)
        {
            Vector3 yawOnly = new Vector3(0, playerHead.eulerAngles.y, 0);
            transform.rotation = Quaternion.Euler(yawOnly);
        }
    }

    void SpawnWeapon()
    {
        GameObject weapon = Instantiate(weaponPrefab);
        var interactable = weapon.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable>();

        if (interactable != null)
        {
            // Wait a frame before placing in socket
            StartCoroutine(AttachNextFrame(interactable));
        }
    }

    IEnumerator AttachNextFrame(UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable interactable)
    {
        yield return null;
        socket.StartManualInteraction(interactable);
        currentWeapon = interactable;
    }

    void OnItemRemoved(SelectExitEventArgs args)
    {
        // The interactable that was just removed
        var interactableObject = args.interactableObject as XRGrabInteractable;
        if (interactableObject != null)
        {
            Rigidbody rb = interactableObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Re-enable physics so it can be thrown
                rb.isKinematic = false;
                rb.useGravity = true;
            }

            // Detach from socket parent
            interactableObject.transform.parent = null;
        }

        // Respawn a new weapon in the holster
        currentWeapon = null;
        Invoke(nameof(SpawnWeapon), 0.05f);
    }
}
