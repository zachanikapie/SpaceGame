using UnityEngine;
using System.Collections;
public class BadFlickerOnCollision : MonoBehaviour
{
    public float flickerInterval = 0.1f; // Time interval between flickers
    public int flickerCount = 10; // Number of flickers

    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if collided with the specific object you want to flicker
        if (collision.gameObject.CompareTag("Ally"))
        {
            StartCoroutine(FlickerCoroutine());
        }
    }

    IEnumerator FlickerCoroutine()
    {
        for (int i = 0; i < flickerCount; i++)
        {
            meshRenderer.enabled = !meshRenderer.enabled;
            yield return new WaitForSeconds(flickerInterval);
        }
        // Ensure the mesh renderer is enabled after flickering
        meshRenderer.enabled = true;
    }
}
