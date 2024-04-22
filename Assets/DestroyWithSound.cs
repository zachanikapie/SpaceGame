using UnityEngine;

public class DestroyWithSound : MonoBehaviour
{
    public AudioClip destructionSound; // Sound to play when the object is destroyed
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Ensure an AudioSource component exists on the same GameObject
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = destructionSound;
    }

    void OnDestroy()
    {
        // Check if a destruction sound is assigned and play it
        if (destructionSound != null && audioSource != null)
        {
            audioSource.Play();
        }
    }
}
