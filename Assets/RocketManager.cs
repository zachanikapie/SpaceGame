using UnityEngine;

public class RocketManager : MonoBehaviour
{
    public int maxRockets = 5; // Maximum number of rockets the player can carry
    private int currentRockets = 0; // Current number of rockets the player has

    // Method to check if the player has rockets available
    public bool HasRockets()
    {
        return currentRockets > 0;
    }

    // Method to decrease the rocket count
    public void UseRocket()
    {
        if (currentRockets > 0)
        {
            currentRockets--;
        }
    }

    // Method to increase the rocket count
    public void AddRocket()
    {
        if (currentRockets < maxRockets)
        {
            currentRockets++;
        }
    }
}
