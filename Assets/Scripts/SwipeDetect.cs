//partially sourced from:
//https://forum.unity.com/threads/detecting-speed-of-the-mouse-move.34572/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetect : MonoBehaviour
{
    public Vector3 mouseDelta = Vector3.zero;

    private Vector3 lastMousePosition = Vector3.zero;

    public float swipeSensitivity = 0.3f;
    public bool isSwipingUp = false;

    // Update is called once per frame
    void Update()
    {
        mouseDelta = (Input.mousePosition - lastMousePosition) * Time.deltaTime;

        lastMousePosition = Input.mousePosition;   

        
        isSwipingUp = (mouseDelta.y > swipeSensitivity);
        
    }
}
