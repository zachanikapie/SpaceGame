using UnityEngine;

public class SporadicMovingEnemy : MonoBehaviour
{
    public float speed = 3f; // Movement speed of the enemy
    public float leftLimit = -5f; // Left limit position
    public float rightLimit = 5f; // Right limit position
    public float topLimit = 5f; // Top limit position
    public float bottomLimit = -5f; // Bottom limit position
    public float yPosition = 15.7f; // Y position of the enemy
    public float minPauseDuration = 1f; // Minimum pause duration
    public float maxPauseDuration = 3f; // Maximum pause duration

    private Vector3 targetPosition; // Target position for the enemy to move towards
    private bool isPaused = false; // Flag to indicate if the enemy is paused
    private float pauseTimer = 0f; // Timer for the current pause duration
    private float currentPauseDuration; // Current pause duration

    private void Start()
    {
        // Set initial target position within the limits
        targetPosition = GetRandomPosition();
        // Set initial pause duration
        currentPauseDuration = Random.Range(minPauseDuration, maxPauseDuration);
    }

    private void Update()
    {
        if (!isPaused)
        {
            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Check if reached the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                // Set a new random target position within the limits
                targetPosition = GetRandomPosition();
                // Start pause
                isPaused = true;
                pauseTimer = 0f;
                // Set new pause duration
                currentPauseDuration = Random.Range(minPauseDuration, maxPauseDuration);
            }
        }
        else
        {
            // Increment pause timer
            pauseTimer += Time.deltaTime;
            // Check if pause duration is over
            if (pauseTimer >= currentPauseDuration)
            {
                isPaused = false;
            }
        }
    }

    // Get a random position within the limits
    private Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(leftLimit, rightLimit);
        float randomZ = Random.Range(bottomLimit, topLimit);
        return new Vector3(randomX, yPosition, randomZ);
    }
}
