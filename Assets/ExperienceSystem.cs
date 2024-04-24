using UnityEngine;
using UnityEngine.UI;

public class ExperienceSystem : MonoBehaviour
{
    public int currentLevel = 1;
    public int currentXP = 0;
    public int maxXP = 100; // Maximum XP needed for level up
    public Slider xpBar; // Reference to the UI slider representing XP bar

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
    }

    // Update UI elements
    void UpdateUI()
    {
        if (xpBar != null)
        {
            xpBar.value = (float)currentXP / maxXP;
        }
    }
}
