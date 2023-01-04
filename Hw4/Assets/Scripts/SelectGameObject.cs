using UnityEngine;

public class SelectGameObject : MonoBehaviour
{
    public GameObject[] gameObjects;
    private GameObject selectedGameObject;
    public float acceleration = 1.0f;
    public float deceleration = 1.0f;
    public float maxSpeed = 5.0f;
    public float translateAmount = 2.0f;
    private float currentSpeed = 0.0f;


    void Start () {
        selectedGameObject = SelectGameObjectF(0);
         // Accelerate the GameObject
        acceleration = 1.0f;
        deceleration = 1.0f;
        maxSpeed = 5.0f;
        currentSpeed = 0.0f;
    }
    
    void Update()
    {
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
       
        currentSpeed += acceleration * Time.deltaTime;

        // Clamp the speed to the max speed
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);

        // Update the position of the GameObject
        selectedGameObject.transform.position += direction * currentSpeed * Time.deltaTime;
    }

    private  GameObject SelectGameObjectF(int index)
    {
        // Make sure the index is within the bounds of the array
        if (index >= 0 && index < gameObjects.Length)
        {
            // Select the GameObject at the specified index
            return gameObjects[index];
            // You can add additional code here to do something with the selected GameObject
        }
        return new GameObject();
    }
}