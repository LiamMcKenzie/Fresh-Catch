//Code sourced from this video
//https://www.youtube.com/watch?v=bK5kYjpqco0
//https://gist.github.com/seferciogluecce/132e136ed71834143100f14b9b86b9fa
using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DragMovement : MonoBehaviour
{
    private Camera mainCamera;
    private float CameraZDistance;

    private Vector3 touchPosition;

    void Start()
    {
        mainCamera = Camera.main;
        CameraZDistance = mainCamera.WorldToScreenPoint(transform.position).z; //z axis of the game object for screen view
    }

    //private float counter = 0;

    void Update(){
        /*
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            touchPosition = mainCamera.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            transform.position = touchPosition;

        }*/
        
        if(Input.GetMouseButton(0)){
            Vector3 ScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.nearClipPlane); //z axis added to screen point 
            Vector3 NewWorldPosition = mainCamera.ScreenToWorldPoint(ScreenPosition); //Screen point converted to world point
            //NewWorldPosition.z = 0;
            transform.position = NewWorldPosition;
        }
    }

    /*
    void OnMouseDrag()
    {
        Vector3 ScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraZDistance); //z axis added to screen point 
        Vector3 NewWorldPosition = mainCamera.ScreenToWorldPoint(ScreenPosition); //Screen point converted to world point

        transform.position = NewWorldPosition;
    }*/
}