using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform firePoint; // Transform where the bullet will be instantiated
    public float bulletSpeed = 10f; // Speed of the bullet

    void Update()
    {
        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        // Instantiate a new bullet at the firePoint's position and rotation
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        // Access the Rigidbody component of the new bullet and set its velocity
        Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = transform.forward * bulletSpeed;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the bullet collides with other objects
        if (other.CompareTag("Enemy")) // Check if the collider has the tag "Enemy"
        {
            // Add code here for what should happen when the bullet collides with an enemy
            Destroy(other.gameObject); // Destroy the collided object
            Destroy(gameObject); // Destroy the bullet
        }
    }
}
