using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public GameObject victoryCanvas;
    public GameObject BossShip;

    private void OnDestroy()
    {
        // Check if the victoryCanvas is assigned
        if (victoryCanvas != null)
        {
            // Enable the canvas when the object is destroyed
            victoryCanvas.SetActive(true);
        }

        // Loop through all GameObjects in the scene
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            // Destroy the object if tagged as "Enemy"
            Destroy(obj);
        }

        if (BossShip != null)
        {
            BossShip.SetActive(false);
        }
    }

    public void DestroyObject()
    {
        // Perform any other necessary actions before destroying the object
        Destroy(gameObject);
    }
}
