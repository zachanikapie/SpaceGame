using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
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

    private bool canLoseLife = true; // Flag to control if the spaceship can lose a life

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
        if (!canLoseLife) // If the spaceship is in cooldown, return without losing a life
            return;

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
        else
        {
            StartCoroutine(StartCooldown());
        }
    }

    IEnumerator StartCooldown()
    {
        canLoseLife = false;
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        canLoseLife = true;
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
