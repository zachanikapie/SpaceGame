using UnityEngine;

public class WallDamage : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage the bullet deals
    public ParticleSystem hitParticle; // Reference to the particle effect

    void OnTriggerEnter(Collider other)
    {
        // Check if the bullet hits an enemy (tag) or a wall (tag)
        if (other.CompareTag("Enemy") || other.CompareTag("Wall"))
        {
            if (other.CompareTag("Enemy"))
            {
                // Get the script component responsible for handling enemy health
                EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

                // Check if the enemyHealth variable is not null
                if (enemyHealth != null)
                {
                    // Deal damage to the enemy
                    enemyHealth.TakeDamage(damageAmount);
                }
            }

            // Instantiate the hit particle at the position of the collision
            if (hitParticle != null)
            {
                Instantiate(hitParticle, transform.position, Quaternion.identity);
            }

        }      
    
    }
}