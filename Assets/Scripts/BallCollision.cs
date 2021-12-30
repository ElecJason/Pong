using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> onPaddleCollision = new UnityEvent<int>();
    [SerializeField] private UnityEvent<int> onWallCollision = new UnityEvent<int>();
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            onPaddleCollision.Invoke(1);
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            onWallCollision.Invoke(2);
        }
    }
}
