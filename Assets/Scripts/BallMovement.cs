using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float startSpeed = 300;
    [SerializeField] private float currentSpeed;

    [SerializeField]
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
        currentSpeed = startSpeed;
        LaunchBall();
    }

    private void LaunchBall()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(currentSpeed * x * Time.deltaTime, currentSpeed * y * Time.deltaTime);
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        currentSpeed = startSpeed;
        LaunchBall();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            rb.velocity *= 1.2f;
        }
    }
}
