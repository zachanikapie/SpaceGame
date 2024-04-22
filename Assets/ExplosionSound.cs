using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public AudioClip hitSound; // Sound to play when the bullet hits an enemy

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is tagged as "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Play the hit sound if available
            if (hitSound != null)
            {
                AudioSource.PlayClipAtPoint(hitSound, transform.position);
            }
            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
