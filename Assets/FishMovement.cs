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

    public float raycastDistance = 5f;
    public float raycastAngleOffset = 45f;

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
            RaycastTurnAroundCheck();
            StartCoroutine(RandomMovementCoroutine());
        }
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

    void RaycastTurnAroundCheck()
    {
        bool hitSomething = false;
        Vector3[] rayDirections = new Vector3[3];
        rayDirections[0] = transform.forward;
        rayDirections[1] = Quaternion.Euler(0f, -raycastAngleOffset, 0f) * transform.forward;
        rayDirections[2] = Quaternion.Euler(0f, raycastAngleOffset, 0f) * transform.forward;

        for (int i = 0; i < 3; i++)
        {
            Debug.DrawRay(transform.position, rayDirections[i] * raycastDistance, Color.green, 2);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, rayDirections[i], out hit, raycastDistance))
            {
                hitSomething = true;
                Debug.Log("Raycast " + (i + 1) + " hit: " + hit.collider.name);
                break;
            }
        }

        if (!hitSomething)
        {
            //StartCoroutine(RandomMovementCoroutine());
        }
    }
}
