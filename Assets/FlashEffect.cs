using UnityEngine;

public class LightIntensityEffect : MonoBehaviour
{
    public Light targetLight;
    public float intensityIncreaseDuration = 1f; // Duration for increasing intensity from 0 to max
    public float intensityDecreaseDuration = 1f; // Duration for decreasing intensity from max to 0
    public float maxIntensity = 200f; // Maximum intensity for the light

    private enum LightState { Increasing, AtMax, Decreasing, Off }
    private LightState currentState = LightState.Increasing;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the light component is assigned
        if (targetLight == null)
        {
            Debug.LogError("Light component is not assigned!");
            enabled = false; // Disable the script if the light component is not assigned
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case LightState.Increasing:
                IncreaseIntensity();
                break;
            case LightState.AtMax:
                LingerAtMax();
                break;
            case LightState.Decreasing:
                DecreaseIntensity();
                break;
            case LightState.Off:
                // Turn off the light
                targetLight.intensity = 0f;
                break;
        }
    }

    // Method to increase intensity gradually
    private void IncreaseIntensity()
    {
        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / intensityIncreaseDuration);
        targetLight.intensity = Mathf.Lerp(0f, maxIntensity, t);
        if (timer >= intensityIncreaseDuration)
        {
            currentState = LightState.AtMax;
            timer = 0f;
        }
    }

    // Method to linger at maximum intensity
    private void LingerAtMax()
    {
        timer += Time.deltaTime;
        if (timer >= 1f) // Linger for 1 second at max intensity
        {
            currentState = LightState.Decreasing;
            timer = 0f;
        }
    }

    // Method to decrease intensity gradually
    private void DecreaseIntensity()
    {
        timer += Time.deltaTime;
        float t = Mathf.Clamp01(timer / intensityDecreaseDuration);
        targetLight.intensity = Mathf.Lerp(maxIntensity, 0f, t);
        if (timer >= intensityDecreaseDuration)
        {
            currentState = LightState.Off;
            timer = 0f;
        }
    }
}
