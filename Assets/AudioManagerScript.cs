using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; // Singleton instance

    private float globalVolume = 1.0f; // Default volume level

    void Awake()
    {
        // Ensure only one instance of AudioManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetGlobalVolume(float volume)
    {
        globalVolume = volume;

        // Find all AudioSources in the scene and adjust their volumes
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in audioSources)
        {
            source.volume = globalVolume;
        }
    }
}
