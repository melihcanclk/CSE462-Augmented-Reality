using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RotateWithArrowKeys : MonoBehaviour
{
    public float rotationSpeed = 50.0f;
    public Light[] lights;
    public KeyCode switchKey;

    // The button that will be used to increase the intensity
    public Button increaseIntensityButton;

    // The button that will be used to decrease the intensity
    public Button decreaseIntensityButton;

    // The amount by which the intensity will be adjusted when the buttons are pressed
    public float intensityAdjustmentAmount = 0.1f;

    private int currentIndex;
    public TextMeshProUGUI currentIndexText;

    void Start ()
    {
        currentIndex = 0;
        currentIndexText.SetText(currentIndex.ToString());

        increaseIntensityButton.onClick.AddListener(OnIncreaseIntensityButtonClicked);
        decreaseIntensityButton.onClick.AddListener(OnDecreaseIntensityButtonClicked);
    }

    void Update()
    {
        if (Input.GetKeyDown(switchKey))
        {
            currentIndex = (currentIndex + 1) % lights.Length;
            currentIndexText.SetText(currentIndex.ToString());
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        lights[currentIndex].transform.Rotate(Vector3.up * horizontal * rotationSpeed * Time.deltaTime);
        lights[currentIndex].transform.Rotate(Vector3.right * vertical * rotationSpeed * Time.deltaTime);
    }

    void OnIncreaseIntensityButtonClicked()
    {
        // Increase the intensity of the light
        lights[currentIndex].intensity += intensityAdjustmentAmount;
    }

    void OnDecreaseIntensityButtonClicked()
    {
        // Decrease the intensity of the light
        lights[currentIndex].intensity -= intensityAdjustmentAmount;
    }

}