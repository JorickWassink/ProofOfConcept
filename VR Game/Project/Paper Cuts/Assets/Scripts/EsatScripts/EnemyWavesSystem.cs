using UnityEngine;
using System.Collections;

public class EnemyWavesSystem : MonoBehaviour
{
    [Header("Wave Settings")]
    int addEnemiesToSpawnAmountMax = 5;
    int addEnemiesToSpawnAmountMin = 1;

    [Tooltip("Time between individual enemy spawns.")]
    float spawnInterval = 0.5f;

    [Tooltip("Time between waves after all enemies are defeated.")]
    float waveInterval = 5f; //  NEW: time between waves

    [Header("Runtime Info")]
    int enemiesToSpawnAmount = 1;
    public int enemiesRemaining = 0;
    int enemiesSpawned = 0;
    int waveAmount = 0;

    bool waveInProgress = false;
    bool waveCoroutineActive = false;
    bool systemActive = true;

    Enemy_Spawn enemySpawn;

    void Start()
    {
        enemySpawn = FindFirstObjectByType<Enemy_Spawn>();
        StartCoroutine(WaveMonitorLoop());
    }

    IEnumerator WaveMonitorLoop()
    {
        while (systemActive)
        {
            // Wait until no enemies are alive and no wave is currently running
            if (enemiesRemaining <= 0 && !waveCoroutineActive)
            {
                yield return StartCoroutine(WaveLoop());
            }

            yield return null; // check again next frame
        }
    }

    IEnumerator WaveLoop()
    {
        waveCoroutineActive = true;
        waveInProgress = true;

        //  Wait between waves
        Debug.Log($" Waiting {waveInterval} seconds before starting next wave...");
        yield return new WaitForSeconds(waveInterval);

        // Configure new wave
        enemiesToSpawnAmount += Random.Range(addEnemiesToSpawnAmountMin, addEnemiesToSpawnAmountMax);
        enemiesRemaining = enemiesToSpawnAmount;
        enemiesSpawned = 0;
        waveAmount++;

        Debug.Log($" Starting wave {waveAmount} ({enemiesToSpawnAmount} enemies)");

        // Spawn enemies gradually
        for (int i = 0; i < enemiesToSpawnAmount; i++)
        {
            enemySpawn.SpawnEnemy();
            enemiesSpawned++;
            yield return new WaitForSeconds(spawnInterval);
        }

        MakeEnemyHarderDifficulty();

        waveInProgress = false;
        waveCoroutineActive = false;
    }

    void MakeEnemyHarderDifficulty()
    {
        // Example: slightly faster spawn rate each wave
        spawnInterval = Mathf.Max(0.1f, spawnInterval - 0.05f);
    }

    public void EnemyDied()
    {
        enemiesRemaining--;
    }

    public void StopWaveSystem()
    {
        systemActive = false;
    }

    public void ResumeWaveSystem()
    {
        if (!systemActive)
        {
            systemActive = true;
            StartCoroutine(WaveMonitorLoop());
        }
    }
}
