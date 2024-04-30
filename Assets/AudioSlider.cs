using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    public Slider audioSlider;  // Reference to the UI Slider

    void Start()
    {
        // Add a listener for when the slider value changes
        audioSlider.onValueChanged.AddListener(delegate { OnSliderChanged(); });
    }

    // Method called when the slider value changes
    void OnSliderChanged()
    {
        // Set the global volume using the AudioManager
        AudioManager.instance.SetGlobalVolume(audioSlider.value);
    }
}
