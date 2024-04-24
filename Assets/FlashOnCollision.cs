using UnityEngine;
using System.Collections;

public class MeshRendererToggle : MonoBehaviour
{
    public float toggleDuration = 2f; // Duration of the toggle in seconds
    public float toggleSpeed = 0.5f; // Speed of the toggle in seconds

    private MeshRenderer meshRenderer;
    private bool isToggling = false;

    void Start()
    {
        // Get the MeshRenderer component attached to the GameObject
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is an enemy
        if (other.CompareTag("Enemy"))
        {
            // Start toggling the MeshRenderer
            StartToggling();
        }
    }

    void StartToggling()
    {
        // Set isToggling to true to start toggling
        isToggling = true;

        // Start the toggle coroutine
        StartCoroutine(ToggleMeshRenderer());
    }

    IEnumerator ToggleMeshRenderer()
    {
        float elapsedTime = 0f;

        while (elapsedTime < toggleDuration)
        {
            // Toggle the MeshRenderer on/off
            meshRenderer.enabled = !meshRenderer.enabled;

            // Wait for a short duration before toggling again
            yield return new WaitForSeconds(toggleSpeed);

            // Update the elapsed time
            elapsedTime += toggleSpeed;
        }

        // Turn on the MeshRenderer if it was turned off
        meshRenderer.enabled = true;

        // Set isToggling to false as the toggle process is finished
        isToggling = false;
    }
}
