using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float swimInterval = 3f;
    public float rotationSpeed = 5f;

    private Rigidbody rb;
    public float timer;
    public Quaternion targetRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = swimInterval;
        
    }

    void Update()
    {
        timer -= Time.deltaTime;
        
        if(timer <= 0f)
        {
            StartCoroutine(RandomMovementCoroutine());
        }
        Debug.DrawRay(transform.position, (Quaternion.Euler(0f, 45f, 0f) * transform.forward) * 5, Color.green);
        Debug.DrawRay(transform.position, (Quaternion.Euler(0f, -45f, 0f) * transform.forward) * 5, Color.green);
        Debug.DrawRay(transform.position, transform.forward * 5, Color.green);
    }

    IEnumerator RandomMovementCoroutine()
    {
        timer = swimInterval;
        
        //randomizes a new direction
        float randomRotationY = Random.Range(0f, 360f);
        targetRotation = Quaternion.Euler(0f, randomRotationY, 0f);

        //rotates towards the random direction
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }

        //waits a second before moving
        yield return new WaitForSeconds(1f);

        //moves forwards in the random direction
        Vector3 forwardDirection = transform.forward;
        rb.velocity = forwardDirection.normalized * moveSpeed;        
    }
}
