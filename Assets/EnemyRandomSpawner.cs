using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomSpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemySpawnSettings
    {
        public GameObject prefab;
        public float spawnInterval = 2f;
        [HideInInspector] public float timer = 0f;
    }

    public List<EnemySpawnSettings> enemySpawnSettings = new List<EnemySpawnSettings>(); // List of enemy spawn settings

    public float spawnBoundaryLeft = -5f; // Left boundary for spawn position
    public float spawnBoundaryRight = 5f; // Right boundary for spawn position

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
                    // Calculate random spawn position within the boundary
                    float randomX = Random.Range(spawnBoundaryLeft, spawnBoundaryRight);
                    Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);

                    // Spawn enemy
                    Instantiate(settings.prefab, spawnPosition, Quaternion.identity);
                    settings.timer = settings.spawnInterval; // Reset timer
                }
            }

            yield return null; // Wait for next frame
        }
    }
}
