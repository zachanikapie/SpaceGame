using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LivesManager : MonoBehaviour
{
    public int startingLives = 3;
    public int maxLives = 3; // Maximum lives allowed
    private int currentLives;

    public int startingRockets = 3;
    public int maxRockets = 5; // Maximum rockets allowed
    public int currentRockets;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI rocketsText; // Text for displaying rocket count
    public GameObject explosionPrefab;
    public GameObject gameOverScreen;
    public GameObject spaceship; // Reference to the spaceship GameObject
    public AudioSource[] gameOverAudioSources; // Array of AudioSource components for game over sounds

    private bool canLoseLife = true; // Flag to control if the spaceship can lose a life

   public void Start()
    {
        currentLives = startingLives;
        currentRockets = startingRockets;
        UpdateUI();
    }

   public void UpdateUI()
    {
        livesText.text = "Lives: " + currentLives;
        rocketsText.text = "Rockets: " + currentRockets; // Update rocket count text
    }

    public void LoseLife()
    {
        if (!canLoseLife) // If the spaceship is in cooldown, return without losing a life
            return;

        currentLives--;
        UpdateUI();
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
            UpdateUI();
        }
    }

    public void UseRocket()
    {
        if (currentRockets > 0)
        {
            currentRockets--;
            UpdateUI();
        }
    }

    public void AddRocket()
    {
        if (currentRockets < maxRockets) // Limit maximum rockets to the maxRockets value
        {
            currentRockets++;
            UpdateUI();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("EnemyBullet"))
        {
            LoseLife();
        }
    }
}
