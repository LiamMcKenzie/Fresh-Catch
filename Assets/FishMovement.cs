using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float swimInterval = 3f;

    private Rigidbody rb;
    public float timer;
    public Vector3 randomDirection;

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
            randomDirection = Random.insideUnitSphere.normalized;
            randomDirection.y = 0f;

            timer = swimInterval;
        }

        rb.velocity = randomDirection * moveSpeed;
    }
}
