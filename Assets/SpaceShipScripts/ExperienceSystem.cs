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
    public GameObject previousObjectBeforeLevel3; // Reference to the GameObject before level 3
    public GameObject level3Object; // Reference to the GameObject to enable at level 3
    public GameObject level6Object; // Reference to the GameObject to enable at level 6
    public GameObject level9Object; // Reference to the GameObject to enable at level 9
    public GameObject level10Object; // Reference to the GameObject to enable at level 10

    void Start()
    {
        // Enable the startup GameObject if it's assigned
        if (previousObjectBeforeLevel3 != null)
        {
            previousObjectBeforeLevel3.SetActive(true);
        }
    }

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

        // Check if the player reached specific levels
        if (currentLevel == 3 || currentLevel == 6 || currentLevel == 9)
        {
            Debug.Log("Reached level " + currentLevel);
            // Disable the previous object before level 3 if it's assigned
            if (previousObjectBeforeLevel3 != null)
            {
                previousObjectBeforeLevel3.SetActive(false);
                Debug.Log("Disabled previous object before level 3");
            }

            // Enable the level 3 GameObject if it's assigned and disable the GameObject corresponding to the previous level
            if (currentLevel == 3 && level3Object != null)
            {
                level3Object.SetActive(true);
                Debug.Log("Enabled level 3 object");
            }

            // Enable the level 6 GameObject if it's assigned and disable the GameObject corresponding to the previous level
            if (currentLevel == 6 && level6Object != null)
            {
                level6Object.SetActive(true);
                Debug.Log("Enabled level 6 object");

                // Disable the level 3 GameObject if it's assigned
                if (level3Object != null)
                {
                    level3Object.SetActive(false);
                    Debug.Log("Disabled level 3 object");
                }
            }

            // Enable the level 9 GameObject if it's assigned and disable the GameObject corresponding to the previous level
            if (currentLevel == 9 && level9Object != null)
            {
                level9Object.SetActive(true);
                Debug.Log("Enabled level 9 object");

                // Disable the level 6 GameObject if it's assigned
                if (level6Object != null)
                {
                    level6Object.SetActive(false);
                    Debug.Log("Disabled level 6 object");
                }
            }
        }

        // Check if the player reached level 10
        if (currentLevel == 10)
        {
            Debug.Log("Reached level 10");
            // Get the current position and rotation of this GameObject
            Vector3 position = transform.position;
            Quaternion rotation = transform.rotation;

            // Disable the attached GameObject
            gameObject.SetActive(false);

            // Enable the level 10 GameObject if it's assigned and move it to the same position and rotation
            if (level10Object != null)
            {
                level10Object.transform.position = position;
                level10Object.transform.rotation = rotation;
                level10Object.SetActive(true);
                Debug.Log("Enabled level 10 object");
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
