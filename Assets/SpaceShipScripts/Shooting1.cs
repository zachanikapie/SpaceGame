using UnityEngine;

public class ShootingRocket : MonoBehaviour
{
    public AudioSource shootSound; // Reference to the AudioSource component for the shoot sound

    void Update()
    {
        // Check for space bar input
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Play the shoot sound
            if (shootSound != null)
            {
                shootSound.Play();
            }
        }
    }
}
