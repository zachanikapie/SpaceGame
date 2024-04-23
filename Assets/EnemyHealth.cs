using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the enemy
    public GameObject healthPickupPrefab; // Health pickup prefab to drop
    public float dropChance = 0.5f; // Chance of dropping the health pickup
    private int currentHealth; // Current health of the enemy

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health
    }

    // Method to take damage
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Reduce current health by the damage amount

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
        if (healthPickupPrefab != null && Random.value <= dropChance)
        {
            // Instantiate the health pickup at the enemy's position
            Instantiate(healthPickupPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject); // Destroy the enemy GameObject
    }
}
