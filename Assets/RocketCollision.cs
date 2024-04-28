using UnityEngine;

public class RocketCollision : MonoBehaviour
{
    public GameObject homingBulletPrefab;
    public int numBullets = 5;

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with something you want to trigger the homing bullets
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Instantiate a cluster of homing bullets
            for (int i = 0; i < numBullets; i++)
            {
                GameObject bullet = Instantiate(homingBulletPrefab, transform.position, Quaternion.identity);
                // Set the target tag for each bullet
                bullet.GetComponent<HomingBullet>().targetTag = "Enemy";
            }

            // Destroy the rocket
            Destroy(gameObject);
        }
    }
}
