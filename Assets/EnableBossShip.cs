using UnityEngine;
using System.Collections;

public class EnableBossShipOnDelay : MonoBehaviour
{
    public GameObject bossShip; // Reference to the BossShip GameObject
    public float delay = 4f; // Delay in seconds before enabling the BossShip

    void Start()
    {
        // Start the coroutine to enable the BossShip after a delay
        StartCoroutine(EnableBossAfterDelay(delay));
    }

    IEnumerator EnableBossAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Check if the BossShip GameObject is assigned and enable it
        if (bossShip != null)
        {
            bossShip.SetActive(true);
        }
        else
        {
            Debug.LogError("BossShip GameObject is not assigned!");
        }
    }
}
