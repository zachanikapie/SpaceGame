using UnityEngine;

public class EnemyPointAtPlayer : MonoBehaviour
{
    public string playerTag = "Player"; // Tag of the player GameObject
    public float rotationSpeed = 5f; // Rotation speed of the enemy

    private GameObject player; // Reference to the player GameObject

    private void Start()
    {
        // Find the GameObject with the specified tag
        player = GameObject.FindGameObjectWithTag(playerTag);
        if (player == null)
        {
            Debug.LogError("Player GameObject not found with tag: " + playerTag);
        }
    }

    private void Update()
    {
        if (player != null)
        {
            // Calculate direction to the player
            Vector3 directionToPlayer = player.transform.position - transform.position;
            directionToPlayer.y = 0f; // Ignore the y component to keep the enemy pointing horizontally

            // Rotate towards the player
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
