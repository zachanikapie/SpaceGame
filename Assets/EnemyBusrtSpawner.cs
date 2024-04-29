using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBurstSpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemySpawnSettings
    {
        public GameObject prefab;
        public float spawnInterval = 2f;
        [HideInInspector] public float timer = 0f;
        public int burstSpawnCount = 5; // Number of enemies to spawn in a burst
    }

    public List<EnemySpawnSettings> enemySpawnSettings = new List<EnemySpawnSettings>(); // List of enemy spawn settings

    private void Start()
    {
        // Initialize timers for each enemy prefab
        foreach (EnemySpawnSettings settings in enemySpawnSettings)
        {
            settings.timer = settings.spawnInterval;
        }

        // Start spawning enemies
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Update timers
            foreach (EnemySpawnSettings settings in enemySpawnSettings)
            {
                settings.timer -= Time.deltaTime;
                if (settings.timer <= 0f)
                {
                    // Spawn burst of enemies
                    for (int i = 0; i < settings.burstSpawnCount; i++)
                    {
                        Instantiate(settings.prefab, transform.position, Quaternion.identity);
                    }
                    settings.timer = settings.spawnInterval; // Reset timer
                }
            }

            yield return null; // Wait for next frame
        }
    }
}
