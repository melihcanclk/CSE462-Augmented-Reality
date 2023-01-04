using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public float FoV = 60.0f;
    public Slider FoVSlider;

    public float RotationSensitivity = 20f;
    public float RotationSmoothness = 0.1f;

    private Transform _cameraTransform;
    private Vector3 _rotation;
    
    void Start()
    {
        // Set the FoVSlider value to the initial FoV value
        FoVSlider.value = FoV;

        _cameraTransform = GetComponentInChildren<Camera>().transform;

    }

    void Update()
    {
        // Update the camera's FoV based on the FoV variable
        GetComponent<Camera>().fieldOfView = FoV;

        if (Input.GetKey(KeyCode.U))
        {
            _rotation.x -= RotationSensitivity * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.J))
        {
            _rotation.x += RotationSensitivity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.K))
        {
            _rotation.y += RotationSensitivity * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.H))
        {
            _rotation.y -= RotationSensitivity * Time.deltaTime;
        }

        _rotation.x = Mathf.Clamp(_rotation.x, -90f, 90f);

        _cameraTransform.localRotation = Quaternion.Lerp(_cameraTransform.localRotation, Quaternion.Euler(_rotation), RotationSmoothness);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, _rotation.y, 0f), RotationSmoothness);
    }

    public void OnValueChanged()
    {
        // Update the FoV variable when the slider value changes
        FoV = FoVSlider.value;
    }
}