using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using System.Collections.Generic;

public class AllPlayersSpawning : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab = null;

    [SerializeField] private Tilemap targetTilemap;         // Reference to the tilemap
    [SerializeField] private TileBase[] allowedTiles;       // Tiles that can be chosen

    private int playerAmount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnObjects(playerPrefab, playerAmount, GetRandomSpawnLocation());
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Spawns a specified number of prefabs at a given 2D location.
    /// </summary>
    /// <param name="paramPlayerPrefab">The player prefab you want to use.</param>
    /// <param name="paramAmountOfPlayers">How many GameObjects to spawn.</param>
    /// <param name="paramLocation">The 2D position to spawn them at.</param>
    public void SpawnObjects(GameObject paramPlayerPrefab, int paramAmountOfPlayers, Vector2 paramLocation)
    {
        if (paramPlayerPrefab == null)
        {
            Debug.LogWarning("No prefab assigned to the spawner!");
            return;
        }

        for (int i = 0; i < paramAmountOfPlayers; i++)
        {
            // Optionally, add a small random offset so they don’t all stack perfectly
            Vector2 spawnPosition = paramLocation + UnityEngine.Random.insideUnitCircle * 0.1f;

            Instantiate(paramPlayerPrefab, spawnPosition, Quaternion.identity);
        }
    }

    /// <summary>
    /// Returns a random world position (Vector2) from one of the allowed tiles in the tilemap.
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

        // Collect all valid positions
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

        // Return random valid position
        if (validPositions.Count == 0)
        {
            Debug.LogWarning("No valid tiles found in the tilemap!");
            return Vector2.zero;
        }

        Vector3Int randomCell = validPositions[UnityEngine.Random.Range(0, validPositions.Count)];

        // Convert from cell position to world position
        Vector3 worldPos = targetTilemap.GetCellCenterWorld(randomCell);

        return (Vector2)worldPos;
    }
}
