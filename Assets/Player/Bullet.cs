using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage the bullet deals

    void OnTriggerEnter(Collider other)
    {
        // Check if the bullet hits an enemy (you may need to adjust the tag or layer check)
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

            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
