using UnityEngine;

public class LifePickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player is tagged as "Player"
        {
            LivesManager livesManager = other.GetComponent<LivesManager>();
            if (livesManager != null)
            {
                livesManager.AddLife();
                // Trigger the sound from the player (spaceship)'s AudioSource
                AudioSource spaceshipAudio = other.GetComponent<AudioSource>();
                if (spaceshipAudio != null && spaceshipAudio.clip != null)
                {
                    spaceshipAudio.PlayOneShot(spaceshipAudio.clip); // Play the sound
                }
                gameObject.SetActive(false); // Deactivate the pickup object
                Destroy(gameObject, 2f); // Destroy the pickup object after 2 seconds
            }
        }
    }
}
