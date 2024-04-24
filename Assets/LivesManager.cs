using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LivesManager : MonoBehaviour
{
    public int startingLives = 3;
    public int maxLives = 3; // Maximum lives allowed
    private int currentLives;

    public TextMeshProUGUI livesText;
    public GameObject explosionPrefab;
    public GameObject gameOverScreen;
    public GameObject spaceship; // Reference to the spaceship GameObject
    public AudioSource[] gameOverAudioSources; // Array of AudioSource components for game over sounds

    void Start()
    {
        currentLives = startingLives;
        UpdateLivesUI();
    }

    void UpdateLivesUI()
    {
        livesText.text = "Lives: " + currentLives;
    }

    public void LoseLife()
    {
        currentLives--;
        UpdateLivesUI();
        if (currentLives <= 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(spaceship); // Destroy the spaceship GameObject
            gameOverScreen.SetActive(true);
            livesText.gameObject.SetActive(false);
            // Play game over sounds using the assigned AudioSource components
            foreach (var audioSource in gameOverAudioSources)
            {
                if (audioSource != null)
                {
                    audioSource.Play();
                }
            }
        }
    }

    public void AddLife()
    {
        if (currentLives < maxLives) // Limit maximum lives to the maxLives value
        {
            currentLives++;
            UpdateLivesUI();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            LoseLife();
        }
    }
}
