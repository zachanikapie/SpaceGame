using UnityEngine;

public class DestroyAllExceptPlayer : MonoBehaviour
{
    private void Start()
    {
        // Find all GameObjects in the scene
        GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();

        // Loop through each GameObject
        foreach (GameObject obj in allGameObjects)
        {
            // Check if the GameObject is tagged as "Player"
            if (obj.CompareTag("Player"))
            {
                continue; // Skip the Player object
            }

            // Check if the GameObject is tagged as "EXP", "Enemy", or "HealthPickup"
            if (obj.CompareTag("EXP") || obj.CompareTag("Enemy") || obj.CompareTag("HealthPickup"))
            {
                // Destroy the GameObject
                Destroy(obj);
            }
        }
    }
}
