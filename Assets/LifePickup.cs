using UnityEngine;

public class LifePickup : MonoBehaviour
{
    public AudioClip pickupSound; // Sound to play when the pickup is collected
    public float destroyDelay = 2f; // Delay before destroying the pickup prefab

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player is tagged as "Player"
        {
            LivesManager livesManager = other.GetComponent<LivesManager>();
            if (livesManager != null)
            {
                livesManager.AddLife();
                AudioSource.PlayClipAtPoint(pickupSound, transform.position); // Play pickup sound
                Debug.Log("Pickup collected by player."); // For debugging
                gameObject.SetActive(false); // Deactivate the pickup prefab
                Destroy(gameObject, destroyDelay); // Destroy the pickup object after a delay
            }
        }
    }
}
