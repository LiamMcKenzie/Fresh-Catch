//partially sourced from:
//https://forum.unity.com/threads/detecting-speed-of-the-mouse-move.34572/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetect : MonoBehaviour
{
    public Vector3 mouseDelta = Vector3.zero;

    private Vector3 lastMousePosition = Vector3.zero;

    public Vector2 newMousePosition;

    public float swipeSensitivity = 0.3f;
    public bool isSwipingUp = false;
    public float timer = 1;
    public float swipeGracePeriod = 0.05f;

    // Update is called once per frame
    void Update()
    {
        if(timer < 0)
        {
            timer = -1;
        }else{
            timer -= Time.deltaTime;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            swipeGracePeriod = 0.05f;
        }


        if(swipeGracePeriod < 0f)
        {
            mouseDelta = (new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height) - newMousePosition) * 1000 * Time.deltaTime;
            swipeGracePeriod = -1;
        }
        else
        {
            swipeGracePeriod -= Time.deltaTime;
        }

        

        
        //mouseDelta = (new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height) - newMousePosition) * 1000 * Time.deltaTime;

        //lastMousePosition = Input.mousePosition;   
        newMousePosition = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);
        
        if(mouseDelta.y > swipeSensitivity)
        {
            timer = 1;
        }
        //isSwipingUp = (mouseDelta.y > swipeSensitivity);
        if(timer > 0)
        {
            isSwipingUp = true;
        }else{
            isSwipingUp = false;
        }

        
        
    }

    
}
