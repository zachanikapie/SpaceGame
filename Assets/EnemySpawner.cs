using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array of enemy prefabs
    public float spawnInterval = 2f; // Time interval between spawns
    public float spawnRadius = 5f; // Radius within which enemies will be spawned along the x-axis
    public float[] spawnProbabilities; // Array of spawn probabilities for each prefab
    public float spawnYPosition = 0f; // Y-coordinate of spawn position

    private void Start()
    {
        // Start spawning enemies
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Randomly select an enemy prefab based on probabilities
            GameObject enemyPrefab = SelectRandomPrefab();

            // Randomly generate spawn position within spawnRadius along the x-axis
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-spawnRadius, spawnRadius), spawnYPosition, 0f);

            // Spawn enemy
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Wait for spawnInterval seconds before spawning next enemy
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    GameObject SelectRandomPrefab()
    {
        float totalProbability = 0f;
        foreach (float probability in spawnProbabilities)
        {
            totalProbability += probability;
        }

        float randomNum = Random.Range(0f, totalProbability);
        float cumulativeProbability = 0f;
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            cumulativeProbability += spawnProbabilities[i];
            if (randomNum <= cumulativeProbability)
            {
                return enemyPrefabs[i];
            }
        }

        // This should never happen, but just in case
        return enemyPrefabs[enemyPrefabs.Length - 1];
    }
}
