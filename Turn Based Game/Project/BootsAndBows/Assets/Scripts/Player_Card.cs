using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class Player_Card : MonoBehaviour
{
    [Header("UI References")]
    public GameObject playerEntryPrefab; // Prefab of one player card
    public Transform contentParent;      // ScrollView → Viewport → Content
    bool hasGenerated = false;

    private PlayerAmountCounter pAC;
    private List<GameObject> playerEntries = new List<GameObject>();

    void Start()
    {
        // Get persistent PlayerAmountCounter (singleton from menu)
        pAC = PlayerAmountCounter.Instance;

        if (pAC == null)
        {
            Debug.LogError("PlayerAmountCounter instance not found!");
            return;
        }
        hasGenerated = false;
    }

    private void Update()
    {
        int playerCount = pAC.PlayerCount;
        Debug.Log($"Creating player cards for {playerCount} players");

        if (hasGenerated == false)
        {
            PopulatePlayerList(playerCount);
            hasGenerated = true;
        }
    }

    void PopulatePlayerList(int playerCount)
    {
        // Clear existing children
        foreach (Transform child in contentParent)
            Destroy(child.gameObject);

        playerEntries.Clear();

        for (int i = 0; i < playerCount; i++)
        {
            GameObject entry = Instantiate(playerEntryPrefab, contentParent);
            entry.transform.localScale = Vector3.one;
            entry.transform.localPosition = Vector3.zero;

            entry.name = $"PlayerCard_{i + 1}";

            // Try to find TMP text + background
            TMP_Text nameText = entry.GetComponentInChildren<TMP_Text>();
            Image bg = entry.GetComponent<Image>();

            if (nameText == null)
            {
                Debug.LogError($"No TMP_Text found in prefab for Player {i + 1}");
                continue;
            }

            if (bg == null)
            {
                Debug.LogError($"No Image component found on prefab for Player {i + 1}");
                continue;
            }

            // Set UI values
            nameText.text = $"Player {i + 1}";
            bg.color = RandomDistinctColor();

            playerEntries.Add(entry);

            Debug.Log($"Created Player {i + 1} card with color {bg.color}");
        }
    }

    Color RandomDistinctColor()
    {
        float hue = Random.value;
        float saturation = 0.7f;
        float value = 0.9f;
        return Color.HSVToRGB(hue, saturation, value);
    }
}
