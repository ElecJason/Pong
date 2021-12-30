using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header("Ball")] public GameObject ball;

    [Header("Player 1")] public GameObject player1;
    public GameObject player1goal;
    
    [Header("Player 2")] public GameObject player2;
    public GameObject player2goal;

    [Header("Score UI")] public GameObject TextPlayer1;
    public GameObject TextPlayer2;

    private int _player1Score;
    private int _player2Score;

    [SerializeField] private UnityEvent Player1Win = new UnityEvent();
    [SerializeField] private UnityEvent Player2Win = new UnityEvent();
    
    // Update is called once per frame
    public void Player1Scored()
    {
        _player1Score++;
        TextPlayer1.GetComponent<TextMeshProUGUI>().text = _player1Score.ToString();
        CheckScore();
        ResetPosition();
    }

    public void Player2Scored()
    {
        _player2Score++;
        TextPlayer2.GetComponent<TextMeshProUGUI>().text = _player2Score.ToString();
        CheckScore();
        ResetPosition();
    }

    private void ResetPosition()
    {
        ball.GetComponent<BallMovement>().Reset();
        player1.GetComponent<PlayerMovement>().Reset();
        player2.GetComponent<PlayerMovement>().Reset();
    }

    private void CheckScore()
    {
        if (_player1Score == 5)
        {
            Debug.Log("Player 1 Wins!");
            PlayerWon();
            Player1Win.Invoke();
        }else if (_player2Score == 5)
        {
            Debug.Log("Player 2 Wins!");
            PlayerWon();
            Player2Win.Invoke();
        }
    }

    private void PlayerWon()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _player1Score = 0;
        _player2Score = 0;
    }
}

