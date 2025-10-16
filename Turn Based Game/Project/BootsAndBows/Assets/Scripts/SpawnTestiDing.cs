using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using System.Collections.Generic;

public class SpawnTestDing : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private int playerAmount = 4;

    [Header("Tilemap Settings")]
    [SerializeField] private Tilemap targetTilemap;
    [SerializeField] private TileBase[] allowedTiles;

    private List<GameObject> spawnedPlayers = new List<GameObject>();

    private void Start()
    {
        SpawnObjects(playerPrefab, playerAmount);
    }

    /// <summary>
    /// Spawns a specified number of prefabs at random allowed locations on the tilemap.
    /// </summary>
    public void SpawnObjects(GameObject paramPlayerPrefab, int paramAmountOfPlayers)
    {
        if (paramPlayerPrefab == null)
        {
            Debug.LogWarning("No prefab assigned to the spawner!");
            return;
        }

        for (int i = 0; i < paramAmountOfPlayers; i++)
        {
            Vector2 spawnPosition = GetRandomSpawnLocation();

            if (spawnPosition == Vector2.zero)
            {
                Debug.LogWarning("Failed to find a valid spawn position!");
                continue;
            }

            GameObject spawned = Instantiate(paramPlayerPrefab, spawnPosition, Quaternion.identity);
            spawnedPlayers.Add(spawned);

            // Assign player ID if the CharacterInfo script exists
            PlayerInfo info = spawned.GetComponent<PlayerInfo>();
            if (info != null)
            {
                info.playerID = i + 1; // Example: Player 1, Player 2, etc.
            }
            else
            {
                Debug.LogWarning($"Spawned object '{spawned.name}' has no CharacterInfo component!");
            }

            // Optional: give the object a clear name in the hierarchy
            spawned.name = $"Player_{i + 1}";
        }
    }

    /// <summary>
    /// Returns a random world position from one of the allowed tiles in the tilemap.
    /// </summary>
    public Vector2 GetRandomSpawnLocation()
    {
        if (targetTilemap == null)
        {
            Debug.LogWarning("No tilemap assigned!");
            return Vector2.zero;
        }

        if (allowedTiles == null || allowedTiles.Length == 0)
        {
            Debug.LogWarning("No allowed tiles assigned!");
            return Vector2.zero;
        }

        List<Vector3Int> validPositions = new List<Vector3Int>();

        BoundsInt bounds = targetTilemap.cellBounds;
        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            TileBase tile = targetTilemap.GetTile(pos);
            if (tile != null && Array.Exists(allowedTiles, t => t == tile))
            {
                validPositions.Add(pos);
            }
        }

        if (validPositions.Count == 0)
        {
            Debug.LogWarning("No valid tiles found in the tilemap!");
            return Vector2.zero;
        }

        Vector3Int randomCell = validPositions[UnityEngine.Random.Range(0, validPositions.Count)];
        Vector3 worldPos = targetTilemap.GetCellCenterWorld(randomCell);

        // Slight random offset to avoid stacking
        worldPos += (Vector3)(UnityEngine.Random.insideUnitCircle * 0.1f);

        return (Vector2)worldPos;
    }
}
