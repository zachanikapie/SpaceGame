using UnityEngine;
using TMPro;

public class LevelIndicator : MonoBehaviour
{
    public ExperienceSystem expSystem; // Reference to the ExperienceSystem script

    private TMP_Text levelText; // Reference to the TextMeshPro Text component

    void Start()
    {
        levelText = GetComponent<TMP_Text>(); // Get the TextMeshPro Text component

        if (expSystem == null)
        {
            Debug.LogError("Reference to ExperienceSystem script is missing!");
        }
    }

    void Update()
    {
        // Update the level indicator text with the current level from the ExperienceSystem script
        if (levelText != null && expSystem != null)
        {
            levelText.text = "Lvl: 2 " + expSystem.currentLevel.ToString();
        }
    }
}
