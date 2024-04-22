using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LivesManager : MonoBehaviour
{
    public int startingLives = 3;
    private int currentLives;

    public TextMeshProUGUI livesText;
    public GameObject explosionPrefab;
    public GameObject gameOverScreen;

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
            gameOverScreen.SetActive(true);
            // Turn off the lives text
            livesText.gameObject.SetActive(false);
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
