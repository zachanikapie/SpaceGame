using UnityEngine;

public class Shooting : MonoBehaviour
{
    public AudioSource shootSound; // Reference to the AudioSource component for the shoot sound

    void Update()
    {
        // Check for space bar input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Play the shoot sound
            if (shootSound != null)
            {
                shootSound.Play();
            }
        }
    }
}
