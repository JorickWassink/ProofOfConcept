using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SocketSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject weaponPrefab;
    public Transform spawnPoint;

    private XRGrabInteractable currentWeapon;

    void Start()
    {
        SpawnWeapon();
    }

    void SpawnWeapon()
    {
        GameObject weapon = Instantiate(weaponPrefab, spawnPoint.position, spawnPoint.rotation, spawnPoint);
        currentWeapon = weapon.GetComponent<XRGrabInteractable>();

        // When weapon is grabbed, unparent it
        currentWeapon.selectEntered.AddListener(OnGrabbed);

        // When weapon is released (after throw), respawn instantly
        currentWeapon.selectExited.AddListener(OnReleased);
    }

    void OnGrabbed(SelectEnterEventArgs args)
    {
        currentWeapon.transform.parent = null; // detach from body
    }

    void OnReleased(SelectExitEventArgs args)
    {
        // Delay optional, but instant for now
        SpawnWeapon();
    }
}
