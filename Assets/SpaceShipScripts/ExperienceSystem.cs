using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExperienceSystem : MonoBehaviour
{
    public int currentLevel = 1;
    public int currentXP = 0;
    public int maxXP = 100; // Maximum XP needed for level up
    public int[] maxXPLevels = { 0, 0, 150, 0, 0, 200, 0, 0, 250 }; // Maximum XP needed for level 3, 6, and 9
    public Slider xpBar; // Reference to the UI slider representing XP bar
    public TextMeshProUGUI levelText; // Reference to TextMeshPro text for displaying level
    public GameObject previousObjectBeforeLevel3; // Reference to the GameObject before level 3
    public GameObject[] level3Objects; // Reference to the GameObjects to enable at level 3
    public GameObject[] level6Objects; // Reference to the GameObjects to enable at level 6
    public GameObject[] level9Objects; // Reference to the GameObjects to enable at level 9
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
        // Determine the max XP based on the current level
        if (currentLevel < maxXPLevels.Length && maxXPLevels[currentLevel] != 0)
        {
            maxXP = maxXPLevels[currentLevel];
        }
        else
        {
            maxXP = 100; // Default max XP
        }
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

            // Enable the level 3 GameObjects if they're assigned and disable the GameObjects corresponding to the previous level
            if (currentLevel == 3 && level3Objects != null)
            {
                foreach (GameObject obj in level3Objects)
                {
                    if (obj != null)
                    {
                        obj.SetActive(true);
                    }
                }
                Debug.Log("Enabled level 3 objects");
            }

            // Enable the level 6 GameObjects if they're assigned and disable the GameObjects corresponding to the previous level
            if (currentLevel == 6 && level6Objects != null)
            {
                foreach (GameObject obj in level6Objects)
                {
                    if (obj != null)
                    {
                        obj.SetActive(true);
                    }
                }
                Debug.Log("Enabled level 6 objects");

                // Disable the level 3 GameObjects if they're assigned
                if (level3Objects != null)
                {
                    foreach (GameObject obj in level3Objects)
                    {
                        if (obj != null)
                        {
                            obj.SetActive(false);
                        }
                    }
                    Debug.Log("Disabled level 3 objects");
                }
            }

            // Enable the level 9 GameObjects if they're assigned and disable the GameObjects corresponding to the previous level
            if (currentLevel == 9 && level9Objects != null)
            {
                foreach (GameObject obj in level9Objects)
                {
                    if (obj != null)
                    {
                        obj.SetActive(true);
                    }
                }
                Debug.Log("Enabled level 9 objects");

                // Disable the level 6 GameObjects if they're assigned
                if (level6Objects != null)
                {
                    foreach (GameObject obj in level6Objects)
                    {
                        if (obj != null)
                        {
                            obj.SetActive(false);
                        }
                    }
                    Debug.Log("Disabled level 6 objects");
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
