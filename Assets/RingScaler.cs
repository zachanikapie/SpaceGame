using UnityEngine;

public class RingScaler : MonoBehaviour
{
    public float growthRate = 1f; // Rate at which the ring grows
    public float maxSize = 10f; // Maximum size of the ring

    private void Update()
    {
        // Check if the ring has reached maximum size
        if (transform.localScale.x < maxSize)
        {
            // Increase the scale of the ring over time
            float scaleFactor = growthRate * Time.deltaTime;
            transform.localScale += new Vector3(scaleFactor, scaleFactor, scaleFactor);
        }
    }
}
