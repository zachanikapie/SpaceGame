using UnityEngine;

public class RocketDamage : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage the bullet deals
    public GameObject homingBulletPrefab; // Reference to the homing bullet prefab
    public int numBullets = 5; // Number of homing bullets to spawn
    public float spreadAngle = 30f; // Angle of spread for the cluster of bullets

    void OnTriggerEnter(Collider other)
    {
        // Check if the bullet hits an enemy (tag) or a wall (tag)
        if (other.CompareTag("Enemy") || other.CompareTag("Wall"))
        {
            // Calculate the angle between each bullet
            float angleIncrement = spreadAngle / (numBullets - 1);
            // Calculate the starting angle
            float startAngle = -spreadAngle / 2f;

            // Instantiate a cluster of homing bullets
            for (int i = 0; i < numBullets; i++)
            {
                // Calculate the rotation for the bullet
                Quaternion bulletRotation = Quaternion.Euler(0f, startAngle + (angleIncrement * i), 0f);
                // Instantiate the homing bullet with the calculated rotation
                GameObject bullet = Instantiate(homingBulletPrefab, transform.position, bulletRotation);
                // Set the target tag for each bullet
                bullet.GetComponent<HomingBullet>().targetTag = "Enemy";
            }

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

            // Destroy the bullet after any collision
            Destroy(gameObject);
        }
    }
}

