using UnityEngine;

public class PrefabMovement : MonoBehaviour
{
    public float initialSpeed = 5f; // Initial speed of the prefab movement
    public float acceleration = 2f; // Acceleration rate
    public string playerTag = "Player"; // Tag of the player GameObject

    private GameObject player; // Reference to the player GameObject
    private float currentSpeed; // Current speed of the prefab movement

    private void Start()
    {
        // Find the player GameObject by tag
        player = GameObject.FindWithTag(playerTag);

        // Check if the player GameObject was found
        if (player == null)
        {
            Debug.LogError("Player GameObject not found! Make sure it has the correct tag.");
        }

        currentSpeed = initialSpeed;
    }

    private void Update()
    {
        if (player != null)
        {
            // Calculate the direction from the prefab to the player
            Vector3 direction = (player.transform.position - transform.position).normalized;

            // Update the current speed with acceleration
            currentSpeed += acceleration * Time.deltaTime;

            // Move the prefab towards the player with the current speed
            transform.Translate(direction * currentSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is the player
        if (other.gameObject == player)
        {
            // Destroy the prefab
            Destroy(gameObject);

            // You can add any additional actions you want to perform here
        }
    }
}
