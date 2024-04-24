using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExperienceSystem : MonoBehaviour
{
    public int currentLevel = 1;
    public int currentXP = 0;
    public int maxXP = 100; // Maximum XP needed for level up
    public Slider xpBar; // Reference to the UI slider representing XP bar
    public TextMeshProUGUI levelText; // Reference to TextMeshPro text for displaying level
    public GameObject level10Object; // Reference to the GameObject to enable at level 10

    // Add XP externally
    public void AddExternalXP(int amount)
    {
        currentXP += amount;
        // Check for level up
        if (currentXP >= maxXP)
        {
            LevelUp();
        }
        UpdateUI();
    }

    // Level up the player
    void LevelUp()
    {
        currentLevel++;
        currentXP = 0; // Reset XP
        // You can add other level up bonuses here
        UpdateLevelText(); // Update the level text when leveling up

        // Check if the player reached level 10
        if (currentLevel == 10)
        {
            // Disable the attached GameObject
            gameObject.SetActive(false);
            // Enable the level 10 GameObject if it's assigned
            if (level10Object != null)
            {
                level10Object.SetActive(true);
            }
        }
    }

    // Update UI elements
    void UpdateUI()
    {
        if (xpBar != null)
        {
            xpBar.value = (float)currentXP / maxXP;
        }
    }

    // Update TextMeshPro text to display current level
    void UpdateLevelText()
    {
        if (levelText != null)
        {
            levelText.text = "Lvl: " + currentLevel.ToString();
        }
    }
}
