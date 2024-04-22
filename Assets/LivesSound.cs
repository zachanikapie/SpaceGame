using UnityEngine;

public class LivesSound : MonoBehaviour
{
    public AudioClip gameOverSound; // Reference to the game over sound
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    // Method to play the game over sound
    public void PlayGameOverSound()
    {
        if (gameOverSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(gameOverSound);
        }
    }
}
