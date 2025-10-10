using UnityEngine;

public class ObjectRespawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private Transform spawner;     // Where to spawn inside the box
    [SerializeField] private GameObject prefab;     // The object to spawn

    private GameObject currentObject;               // Tracks the currently spawned object

    void Start()
    {
        SpawnObject();
    }

    private void SpawnObject()
    {
        if (currentObject != null) return; // Don’t double-spawn

        currentObject = Instantiate(prefab, spawner.position, spawner.rotation);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("that shit is OUT da box");
        // Only respawn if the current object left the box
        if (currentObject != null && other.gameObject == currentObject)
        {
            print("bark tuah");
            // Detach the old one so it can fly freely
            currentObject.transform.parent = null;
            // Allow time for the player to fully remove it
            Invoke(nameof(SpawnObject), 0.1f);
            // Clear the reference so we know it’s gone
            currentObject = null;
        }
    }
}
