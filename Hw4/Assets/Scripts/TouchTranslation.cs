using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTranslation : MonoBehaviour
{
    // Variables to store touch position and starting position
    Vector2 touchPosition, startPosition;

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Store touch position and starting position
            touchPosition = touch.position;
            startPosition = transform.position;
            Debug.Log("sadasd");
        }

        // Calculate touch delta and update object position
        Vector3 touchDelta = Camera.main.ScreenToWorldPoint(touchPosition) - Camera.main.ScreenToWorldPoint(startPosition);
        transform.position += touchDelta;
    }
}
