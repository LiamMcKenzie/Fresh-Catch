using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCaught : MonoBehaviour
{
    private Vector3 startPosition;
    public GameObject targetObject;
    private Vector3 targetPosition;
    public float duration = 2.0f;
    private float startTime;
    private bool isLerping = false;

    void Start()
    {
        // Initialize the start and target positions
        startPosition = transform.position;
        targetObject = Camera.main.transform.Find("UI Fish").gameObject;
    }

    void Update()
    {
        if(isLerping)
        {
            targetPosition = targetObject.transform.position; // Change this to your desired target position
            // Calculate the time that has passed since the movement started
            float elapsedTime = Time.time - startTime;

            if (elapsedTime < duration)
            {
                // Interpolate between the start and target positions
                float t = elapsedTime / duration;
                transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            }
            else
            {
                // The movement is complete
                transform.position = targetPosition;
                isLerping = false;
            }
        }
        
    }

    // Call this function to start the interpolation
    public void StartLerp()
    {
        isLerping = true;
        startTime = Time.time;
    }
}
