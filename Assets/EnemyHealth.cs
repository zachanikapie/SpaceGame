using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the enemy
    public GameObject healthPickupPrefab; // Health pickup prefab to drop
    public float healthDropChance = 0.5f; // Chance of dropping the health pickup
    public GameObject rocketRefillPrefab; // Rocket refill pickup prefab to drop
    public float rocketRefillDropChance = 0.3f; // Chance of dropping the rocket refill pickup
    private int currentHealth; // Current health of the enemy

    // Particle effect to play when hit
    public ParticleSystem hitParticle;

    // Cluster object to drop when the enemy dies
    public GameObject clusterObject; // The object of the cluster to drop
    public int clusterCount = 3;     // Number of clusters to drop
    public float clusterSpread = 1f; // Spread radius of the clusters

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health
    }

    // Method to take damage
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Reduce current health by the damage amount

        // Play hit particle effect
        if (hitParticle != null)
        {
            Instantiate(hitParticle, transform.position, Quaternion.identity);
        }

        // Check if the enemy's health has reached zero or below
        if (currentHealth <= 0)
        {
            Die(); // Call the Die method if the enemy is killed
        }
    }

    // Method to handle the enemy's death
    void Die()
    {
        // Perform any death-related actions here, such as playing death animation, dropping items, etc.

        // Check if the health pickup prefab is assigned and if the drop chance is met
        if (healthPickupPrefab != null && Random.value <= healthDropChance)
        {
            // Instantiate the health pickup at the enemy's position
            Instantiate(healthPickupPrefab, transform.position, Quaternion.identity);
        }

        // Check if the rocket refill pickup prefab is assigned and if the drop chance is met
        if (rocketRefillPrefab != null && Random.value <= rocketRefillDropChance)
        {
            // Instantiate the rocket refill pickup at the enemy's position
            Instantiate(rocketRefillPrefab, transform.position, Quaternion.identity);
        }

        // Check if the cluster object is assigned
        if (clusterObject != null)
        {
            // Drop clusters
            DropClusters();
        }

        Destroy(gameObject); // Destroy the enemy GameObject
    }

    // Method to drop clusters
    private void DropClusters()
    {
        for (int i = 0; i < clusterCount; i++)
        {
            // Calculate random position within spread radius
            Vector3 randomPosition = transform.position + Random.insideUnitSphere * clusterSpread;

            // Instantiate cluster object at the random position
            Instantiate(clusterObject, randomPosition, Quaternion.identity);
        }
    }
}
