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

    public GameObject bobber;

    public  bool[] rayHits = new bool[3];
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
            //RandomMovement();
        }
        CheckFOV();
    }

    void RandomMovement()
    {
        //randomizes a new direction
        float randomRotationY = Random.Range(0f, 360f);
        targetRotation = Quaternion.Euler(0f, randomRotationY, 0f);

        //rotates towards the random direction
        StartCoroutine(MovementCoroutine());
    }

    void TurnAround(float newRotation)
    {
        //passes in new direction
       
        //Debug.Log(transform.eulerAngles.y + "+" +  newRotation);
        targetRotation = Quaternion.Euler(0f, transform.eulerAngles.y + newRotation, 0f);

        //rotates towards the new direction
        StartCoroutine(MovementCoroutine());
    }

    IEnumerator MovementCoroutine()
    {
        timer = swimInterval;
        
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }

        //waits a second before moving
        yield return new WaitForSeconds(1f);
        

        //moves forwards in the random direction
        rb.velocity = transform.forward.normalized * moveSpeed;  
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
            rayHits[i] = false;
            if (Physics.Raycast(transform.position, rayDirections[i], out hit, raycastDistance))
            {
                hitSomething = true;
                rayHits[i] = true;
                //Debug.Log("Raycast " + (i + 1) + " hit: " + hit.collider.name);
                //break;
            }
        }

        if(rayHits[1] && rayHits[2] || rayHits[0])
        {
            TurnAround(180f);
            Debug.Log("turn around");
            //both hit
        }
        else if(rayHits[1] && !rayHits[2])
        {
            TurnAround(90f);
            Debug.Log("turn right");
            //only left raycast hit
        }
        else if(rayHits[2] && !rayHits[1])
        {
            TurnAround(-90f);
            Debug.Log("turn left");
            //only right raycast hit
        }
        else if (!hitSomething)
        {
            RandomMovement();
        }
    }

    //https://discussions.unity.com/t/check-if-player-is-in-enemys-fov/182973
    void CheckFOV()
    {
        Vector3 targetDir = bobber.transform.position - transform.position; 
        float angleToPlayer = (Vector3.Angle(targetDir, transform.forward)); 
        if(angleToPlayer >= -90 && angleToPlayer <= 90)
        {
            Debug.Log("Player in sight!");
        }
        // 180° FOV 
    }
    
}
