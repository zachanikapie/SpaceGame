using UnityEngine;
using TMPro;

public class ScoringSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to TextMeshPro text for displaying score
    public int currentScore = 0; // Current score of the player

    // Add score externally
    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreText();
    }

    // Update TextMeshPro text to display current score
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }
}
