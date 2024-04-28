using UnityEngine;

public class RocketPickup : MonoBehaviour
{
    private LivesManager livesManager; // Reference to the LivesManager script
    public int rocketsToAdd = 1; // Number of rockets to add when picked up
    public GameObject pickupEffect; // Effect to play when the pickup is collected

    void Start()
    {
        // Attempt to find the LivesManager component in the scene
        livesManager = FindObjectOfType<LivesManager>();
        if (livesManager == null)
        {
            Debug.LogWarning("No LivesManager found in the scene.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with the rocket pickup
        if (other.CompareTag("Player") && livesManager != null)
        {
            // Add rockets to the player's rocket count
            livesManager.currentRockets += rocketsToAdd;
            // Clamp the rocket count to ensure it doesn't exceed the maximum
            livesManager.currentRockets = Mathf.Min(livesManager.currentRockets, livesManager.maxRockets);

            // Update the UI
            livesManager.UpdateUI();

            // Play pickup effect if available
            if (pickupEffect != null)
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
            }

            // Destroy the pickup object
            Destroy(gameObject);
        }
    }
}
