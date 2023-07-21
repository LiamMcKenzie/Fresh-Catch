//Code sourced from this forum
//https://gamedev.stackexchange.com/questions/75649/how-do-i-get-mouse-x-y-of-the-world-plane-in-unity

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    //public bool mouseDown;
    //public int touchcount;

    public float minimumZPos;
    public float maximumZPos;
    public float lerpZPos;

    void Update(){
        if(Input.GetMouseButton(0)){
            transform.position = GetMousePositionOnXZPlane();
        }

        Vector3 pos = transform.position;
        pos.z = Mathf.Clamp(transform.position.z, minimumZPos, maximumZPos);
        transform.position = pos;

        //mouseDown = Input.GetMouseButton(0);
        //touchcount = Input.touchCount;

        lerpZPos = Mathf.InverseLerp(minimumZPos, maximumZPos, transform.position.z);
    }

    static Plane XZPlane = new Plane(Vector3.up, Vector3.zero);

    public static Vector3 GetMousePositionOnXZPlane() {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(XZPlane.Raycast (ray, out distance)) {
            Vector3 hitPoint = ray.GetPoint(distance);
            //Just double check to ensure the y position is exactly zero
            hitPoint.y = 0;
            return hitPoint;
        }
        return Vector3.zero;
    }
}   