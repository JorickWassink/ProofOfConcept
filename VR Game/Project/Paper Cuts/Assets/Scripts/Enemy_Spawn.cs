using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Enemy_Spawn : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();


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

    public void EnemySpawnInterval()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);

        if (timer <= 0f)
        {
            SpawnEnemy();
            timer = spawnInterval; // Reset timer
        }
    }

    public void SpawnEnemy()
    {
        Debug.Log("spawn");
        if (spawnPoints.Length == 0 || enemyPrefab.Length == 0)
            return;

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject prefabToSpawn = enemyPrefab[Random.Range(0, enemyPrefab.Length)];

        enemies.Add(Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation));
    }
}
