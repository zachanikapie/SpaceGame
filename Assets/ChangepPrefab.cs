using UnityEngine;

public class ChangePrefab : MonoBehaviour
{
    public GameObject originalPrefab; // The original prefab you want to replace
    public GameObject newPrefab; // The prefab you want to replace it with

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // Change prefab when 'C' key is pressed
        {
            ReplacePrefab();
        }
    }

    void ReplacePrefab()
    {
        // Get the position and rotation of the original prefab
        Vector3 position = originalPrefab.transform.position;
        Quaternion rotation = originalPrefab.transform.rotation;

        // Instantiate the new prefab at the same position and rotation
        GameObject newObject = Instantiate(newPrefab, position, rotation);

        // Copy any necessary properties from the original prefab to the new one
        // For example, you might want to copy the original prefab's parent or scale

        // Destroy the original prefab
        Destroy(originalPrefab);
    }
}
