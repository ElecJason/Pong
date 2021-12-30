using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoalBehavior : MonoBehaviour
{
    [SerializeField] private bool isPlayer1Goal;
    [SerializeField] private UnityEvent<int> player1Score = new UnityEvent<int>();
    [SerializeField] private UnityEvent<int> player2Score = new UnityEvent<int>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.gameObject.CompareTag("Ball"))
        {
            if (!isPlayer1Goal)
            {
                player1Score.Invoke(3);
            }
            else
            {
                player2Score.Invoke(3);
            }
        }
    }
}
