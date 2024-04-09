using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of movement
    public float minX = -23f; // Minimum X position
    public float maxX = 23f; // Maximum X position
    public float minZ = -45f; // Minimum Z position
    public float maxZ = 44f; // Maximum Z position

    private Vector3 targetPosition;

    void Start()
    {
        // Set the initial target position
        SetRandomTargetPosition();
    }

    void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the enemy has reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Set a new random target position
            SetRandomTargetPosition();
        }
    }

    void SetRandomTargetPosition()
    {
        // Generate a random position within the specified boundaries
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        targetPosition = new Vector3(randomX, transform.position.y, randomZ);
    }
}
