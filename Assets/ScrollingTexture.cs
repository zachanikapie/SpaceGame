using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{
    public Renderer rend;
    public float scrollSpeed = 0.5f; // Base scroll speed
    public float forwardSpeedMultiplier = 1.5f; // Speed multiplier when moving forward
    public float backwardSpeedMultiplier = 0.5f; // Speed multiplier when moving backward
    private float offset;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        // Get input from the user
        float forwardInput = Input.GetAxis("Vertical");

        // Calculate the speed based on the forward movement
        float currentSpeed = forwardInput > 0 ? scrollSpeed * forwardSpeedMultiplier : forwardInput < 0 ? scrollSpeed * backwardSpeedMultiplier : scrollSpeed;

        // Calculate the offset based on time and speed
        offset += currentSpeed * Time.deltaTime;

        // Apply the offset to the material in the opposite direction
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));
    }
}
