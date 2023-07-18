//Code sourced from this forum
//https://gamedev.stackexchange.com/questions/75649/how-do-i-get-mouse-x-y-of-the-world-plane-in-unity

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    void Update(){
        if(Input.GetMouseButton(0)){
            transform.position = GetMousePositionOnXZPlane();
        }
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