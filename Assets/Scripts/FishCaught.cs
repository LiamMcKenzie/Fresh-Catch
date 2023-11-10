using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCaught : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 targetPosition;

    public GameObject targetObject;
    
    private Quaternion startRotation;
    private Quaternion targetRotation;

    public float duration = 0.001f;
    private float startTime;
    private bool isLerping = false;

    void Start()
    {
        // Initialize the start and target positions
        startPosition = transform.position;
        startRotation = transform.rotation;

        targetObject = Camera.main.transform.Find("UI Fish").gameObject;
    }

    void Update()
    {
        if(isLerping)
        {
            targetPosition = targetObject.transform.position; // Change this to your desired target position
            targetRotation = targetObject.transform.rotation; 
            // Calculate the time that has passed since the movement started
            float elapsedTime = Time.time - startTime;

            if (elapsedTime < duration)
            {
                // Interpolate between the start and target positions
                float t = elapsedTime / duration;
                transform.position = Vector3.Lerp(startPosition, targetPosition, t);
                
                transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);

            }
            else
            {
                // The movement is complete
                transform.position = targetPosition;
                transform.rotation = targetRotation;
                isLerping = false;
            }
        }
        
    }

    // Call this function to start the interpolation
    public void StartLerp()
    {
        isLerping = true;
        startTime = Time.time;
        gameObject.GetComponent<FishMovement>().alertIcon.SetActive(false);
    }
}
