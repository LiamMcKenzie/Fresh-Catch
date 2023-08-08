using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPosition : MonoBehaviour
{
    public Vector3 target;
    public float smoothSpeed = 3f;

    public float minimumXPos = -4;
    public float maximumXPos = 4;

    public float minimumZPos = -5f;
    public float maximumZPos = 3.75f;

    public float lerpXPos;
    public float lerpZPos;
    
    public LineRenderer lineRenderer;

    public DragObject DragObjectScript;

    public GameObject lineAnchor;

    // Update is called once per frame

    void Update()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;  

        lineRenderer.SetPosition(0, transform.position); //x,y and z position of the starting point of the line
        lineRenderer.SetPosition(1, lineAnchor.transform.position);

        target = transform.position;
        
        lerpXPos = Mathf.Lerp(minimumXPos, maximumXPos, DragObjectScript.lerpXPos);
        lerpZPos = Mathf.Lerp(minimumZPos, maximumZPos, DragObjectScript.lerpZPos);

        target.x = Mathf.Clamp(lerpXPos, minimumXPos, maximumXPos);
        target.z = Mathf.Clamp(lerpZPos, minimumZPos, maximumZPos);
        
        //transform.position = pos;

        //mouseDown = Input.GetMouseButton(0);
        //touchcount = Input.touchCount;
        

        //transform.position = new Vector3(lerpXPos, transform.position.y, lerpZPos);

    }


    void FixedUpdate()
    {
        //Vector3 newPosition = target.transform.position - target.transform.forward * offset.z - target.transform.up * offset.y;
        //transform.position = Vector3.Slerp(transform.position, newPosition, Time.deltaTime * 5);

        transform.position = Vector3.Slerp(transform.position, target, Time.deltaTime * smoothSpeed);
    }
}
