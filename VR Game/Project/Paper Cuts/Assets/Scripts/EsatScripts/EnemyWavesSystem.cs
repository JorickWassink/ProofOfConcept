using System.Collections.Generic;
using UnityEngine;

public class EnemyWavesSystem : MonoBehaviour
{
    private PrefabManager Prefab => PrefabManager.Instance;

    List<DamageEnemy> allEnemies = new();

    public int enemiesRemaining = 0;

    public int addEnemiesToSpawnAmountMax = 5;
    public int addEnemiesToSpawnAmountMin = 1;

    private int enemiesToSpawnAmount = 5;

    GameObject enemyToSpawn = null;
    List<GameObject> enemySpawnPoints = new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemiesToSpawnAmount; i++) 
        {
            // Spawn enemy at enemy spawn point

        }
    }

    void GetRandomEnemySpawnPoint()
    {
        
    }

    GameObject GetRandomEnemy()
    {
        int randomNum = Random.Range(0, 3);
        if (randomNum == 0)
        {
            enemyToSpawn = Prefab.Rock;
        }
        else if (randomNum == 1)
        {
            enemyToSpawn = Prefab.Paper;
        }
        else
        {
            enemyToSpawn = Prefab.Scissor;
        }
        return enemyToSpawn;
    }
}
