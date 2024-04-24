using UnityEngine;

public class PickupSoundHandler : MonoBehaviour
{
    public AudioSource healthPickupAudioSource; // AudioSource for health pickup sound
    public AudioSource ammoPickupAudioSource; // AudioSource for ammo pickup sound

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthPickup"))
        {
            PlaySound(healthPickupAudioSource);
        }
        else if (other.CompareTag("AmmoPickup"))
        {
            PlaySound(ammoPickupAudioSource);
        }
    }

    private void PlaySound(AudioSource audioSource)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
