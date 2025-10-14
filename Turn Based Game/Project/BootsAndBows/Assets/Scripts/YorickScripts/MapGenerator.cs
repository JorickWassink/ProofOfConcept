using UnityEngine;
using UnityEngine.Tilemaps;

[ExecuteInEditMode]
public class MapGenerator : MonoBehaviour
{
    [Header("Tilemap Settings")]
    public Tilemap tilemap;

    [Header("Tiles to Randomize")]
    public TileBase[] randomTiles; // voeg hier meerdere tiles in toe

    [Header("Area Settings")]
    public int width = 10;
    public int height = 10;
    public Vector3Int startPos = Vector3Int.zero;

    [Header("Options")]
    [Range(0f, 1f)]
    public float fillChance = 1f; // 1 = altijd een tile plaatsen, 0.5 = 50% kans

    private void Start()
    {
        GenerateRandomTiles();
    }
    [ContextMenu("Generate Random Tiles")]
    public void GenerateRandomTiles()
    {
        if (tilemap == null)
        {
            tilemap = GetComponent<Tilemap>();
            if (tilemap == null)
            {
                Debug.LogError("Geen Tilemap component gevonden!");
                return;
            }
        }

        if (randomTiles == null || randomTiles.Length == 0)
        {
            Debug.LogError("Geen tiles toegewezen!");
            return;
        }

        tilemap.ClearAllTiles();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (Random.value > fillChance)
                    continue;

                TileBase randomTile = randomTiles[Random.Range(0, randomTiles.Length)];
                Vector3Int pos = new Vector3Int(startPos.x + x, startPos.y + y, 0);
                tilemap.SetTile(pos, randomTile);
            }
        }

        Debug.Log($"Random tiles geplaatst in gebied {width}x{height} vanaf {startPos}.");
    }
}
