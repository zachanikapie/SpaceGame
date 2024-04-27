using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
    // The speed at which the object rotates towards the player
    public float rotationSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Find the player GameObject with the "Player" tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // If player is found
        if (player != null)
        {
            // Determine the direction to the player
            Vector3 direction = player.transform.position - transform.position;

            // If there's a direction (avoid division by zero)
            if (direction != Vector3.zero)
            {
                // Rotate the object to face the player's position smoothly
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
