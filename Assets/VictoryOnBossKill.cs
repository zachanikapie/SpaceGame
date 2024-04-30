using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public GameObject victoryCanvas;

    private void OnDestroy()
    {
        // Check if the victoryCanvas is assigned
        if (victoryCanvas != null)
        {
            // Enable the canvas when the object is destroyed
            victoryCanvas.SetActive(true);
        }
    }

    public void DestroyObject()
    {
        // Perform any other necessary actions before destroying the object
        Destroy(gameObject);
    }
}
