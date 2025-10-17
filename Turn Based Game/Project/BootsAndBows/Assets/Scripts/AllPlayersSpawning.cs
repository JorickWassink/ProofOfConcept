using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class AllPlayersSpawning : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private Tilemap targetTilemap;

    public List<GameObject> AllSpawnedPlayers = new List<GameObject>();

    [SerializeField] private int playerAmount = 2; // Configurable in Inspector

    void Awake()
    {
        SpawnObjects(playerPrefab, playerAmount);
    }

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

        // Collect valid tile positions
        List<Vector3Int> validPositions = new List<Vector3Int>();
        BoundsInt bounds = targetTilemap.cellBounds;

        foreach (var pos in bounds.allPositionsWithin)
        {
            TileBase tile = targetTilemap.GetTile(pos);
            if (tile != null)
                validPositions.Add(pos);
        }

        if (validPositions.Count == 0)
        {
            Debug.LogWarning("No tiles found in the tilemap!");
            return;
        }

        // Shuffle positions for randomness
        for (int i = 0; i < validPositions.Count; i++)
        {
            Vector3Int temp = validPositions[i];
            int randomIndex = Random.Range(i, validPositions.Count);
            validPositions[i] = validPositions[randomIndex];
            validPositions[randomIndex] = temp;
        }

        // Spawn players (teams)
        int spawnCount = Mathf.Min(paramAmountOfPlayers, validPositions.Count);
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3Int cell = validPositions[i];
            Vector3 worldPos = targetTilemap.GetCellCenterWorld(cell);
            GameObject newPlayer = Instantiate(paramPlayerPrefab, worldPos, Quaternion.identity);

            // Assign player ID
            PlayerInfo info = newPlayer.GetComponent<PlayerInfo>();
            if (info != null)
            {
                info.playerID = i;

                // Random team color
                Color teamColor = new Color(Random.value, Random.value, Random.value);

                // Apply to all child SpriteRenderers
                SpriteRenderer[] renderers = newPlayer.GetComponentsInChildren<SpriteRenderer>();
                foreach (var renderer in renderers)
                {
                    renderer.color = teamColor;
                }
            }

            AllSpawnedPlayers.Add(newPlayer);
        }

        Debug.Log($"Spawned {AllSpawnedPlayers.Count} teams with random colors!");
    }
}
