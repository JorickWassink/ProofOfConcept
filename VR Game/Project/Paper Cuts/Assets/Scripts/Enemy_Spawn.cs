using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject[] enemyPrefab; // Enemy prefab

    [Header("Spawn Points")]
    public Transform[] spawnPoints; // Alle spawnpoints

    [Header("Spawn Settings")]
    public float spawnInterval = 3f; // Hoe vaak gespawned moet worden
    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnEnemy();
            timer = spawnInterval; // Reset timer
        }
    }
    
    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0 || enemyPrefab.Length == 0)
            return;

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject prefabToSpawn = enemyPrefab[Random.Range(0, enemyPrefab.Length)];

        Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}
