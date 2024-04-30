using UnityEngine;

public class ColliderActivator : MonoBehaviour
{
    public GameObject[] objectsToWatch; // Reference to the objects whose presence we are tracking
    public Collider colliderToEnable; // Reference to the collider we want to enable

    void Update()
    {
        // Check if all objects are missing (destroyed)
        if (AreAllObjectsMissing())
        {
            // Enable the collider
            colliderToEnable.enabled = true;
        }
    }

    bool AreAllObjectsMissing()
    {
        foreach (GameObject obj in objectsToWatch)
        {
            if (obj != null) // Object still exists
            {
                return false;
            }
        }
        return true; // All objects are missing
    }
}
