using UnityEngine;

public class MoveAndTranslate : MonoBehaviour
{
    public float acceleration = 1.0f;
    public float deceleration = 1.0f;
    public float maxSpeed = 5.0f;
    public float translateAmount = 2.0f;
    private float currentSpeed = 0.0f;
    public GameObject[] gameObjects;

    void Update()
    {
        // Initialize the input to zero
        // User Defined axis
        float horizontalInput = 0.0f;
        float verticalInput = 0.0f;
        float depthInput = 0.0f;

        // Check if the W, S, A, D, space, or Ctrl keys are pressed
        if (Input.GetKey(KeyCode.W))
        {
            depthInput = 1.0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            depthInput = -1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1.0f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1.0f;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            verticalInput = 1.0f;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            verticalInput = -1.0f;
        }
        // Calculate the direction to move in
        Vector3 direction = new Vector3(horizontalInput, verticalInput, depthInput);

        // Normalize the direction to get a unit vector (magnitude of 1)
        direction = direction.normalized;

        // Accelerate the GameObject
        currentSpeed += acceleration * Time.deltaTime;

        // Clamp the speed to the max speed
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

        
    }
}