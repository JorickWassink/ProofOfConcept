using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class AllPlayersSpawning : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private Tilemap targetTilemap; // Reference to the tilemap

    //  List to keep track of all spawned players
    public List<GameObject> AllSpawnedPlayers = new List<GameObject>();

    //PlayerAmountCounter playerAmount = FindFirstObjectByType<PlayerAmountCounter>();

    void Start()
    {
        SpawnObjects(playerPrefab, 8);
    }

    /// <summary>
    /// Spawns a specified number of prefabs at random tile locations.
    /// </summary>
    public void SpawnObjects(GameObject paramPlayerPrefab, int paramAmountOfPlayers)
    {
        if (paramPlayerPrefab == null)
        {
            Debug.LogWarning("No prefab assigned to the spawner!");
            return;
        }

        if (targetTilemap == null)
        {
            Debug.LogWarning("No tilemap assigned to the spawner!");
            return;
        }

        // Get all valid tile positions first
        List<Vector3Int> validPositions = new List<Vector3Int>();
        BoundsInt bounds = targetTilemap.cellBounds;

        foreach (var pos in bounds.allPositionsWithin)
        {
            TileBase tile = targetTilemap.GetTile(pos);
            if (tile != null)
            {
                validPositions.Add(pos);
            }
        }

        if (validPositions.Count == 0)
        {
            Debug.LogWarning("No tiles found in the tilemap!");
            return;
        }

        // Shuffle the tile positions to ensure randomness and no repeats
        for (int i = 0; i < validPositions.Count; i++)
        {
            Vector3Int temp = validPositions[i];
            int randomIndex = Random.Range(i, validPositions.Count);
            validPositions[i] = validPositions[randomIndex];
            validPositions[randomIndex] = temp;
        }

        // Spawn players on different tiles (or as many as available)
        int spawnCount = Mathf.Min(paramAmountOfPlayers, validPositions.Count);

        for (int i = 0; i < spawnCount; i++)
        {
            Vector3Int cell = validPositions[i];
            Vector3 worldPos = targetTilemap.GetCellCenterWorld(cell);
            GameObject newPlayer = Instantiate(paramPlayerPrefab, worldPos, Quaternion.identity);

            // Add the new player to the list
            AllSpawnedPlayers.Add(newPlayer);

            //Assign player ID if the CharacterInfo script exists
            PlayerInfo info = newPlayer.GetComponent<PlayerInfo>();
            if (info != null)
            {
                info.playerID = i + 1; // Example: Player 1, Player 2, etc.
            }
            else
            {
                Debug.LogWarning($"Spawned object '{newPlayer.name}' has no CharacterInfo component!");
            }
        }

        Debug.Log($"Spawned {AllSpawnedPlayers.Count} players on unique tiles!");
    }
}
