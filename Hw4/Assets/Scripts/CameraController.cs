using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public float FoV = 60.0f;
    public Slider FoVSlider;

    void Start()
    {
        // Set the FoVSlider value to the initial FoV value
        FoVSlider.value = FoV;
    }

    void Update()
    {
        // Update the camera's FoV based on the FoV variable
        GetComponent<Camera>().fieldOfView = FoV;
    }

    public void OnValueChanged()
    {
        // Update the FoV variable when the slider value changes
        FoV = FoVSlider.value;
    }
}