using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPosition : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 newPosition = target.transform.position - target.transform.forward * offset.z - target.transform.up * offset.y;
        //transform.position = Vector3.Slerp(transform.position, newPosition, Time.deltaTime * 5);

        transform.position = Vector3.Slerp(transform.position, target.position, Time.deltaTime * smoothSpeed);
    }
}
