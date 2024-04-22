using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class LivesManager : MonoBehaviour
{
    public int startingLives = 3;
    private int currentLives;

    public TextMeshProUGUI livesText; // Reference to the TextMeshPro UI text displaying lives

    void Start()
    {
        currentLives = startingLives;
        UpdateLivesUI();
    }

    void UpdateLivesUI()
    {
        // Update the UI text to display the current lives
        livesText.text = "Lives: " + currentLives;
    }

    public void LoseLife()
    {
        currentLives--;
        UpdateLivesUI();
        if (currentLives <= 0)
        {
            // Trigger game over sequence
            Debug.Log("Game Over!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // If collided with an enemy, lose a life
            LoseLife();
        }
    }
}
