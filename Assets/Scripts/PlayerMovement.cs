using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool isPlayer1;
    [SerializeField] private float speed = 1000;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector3 startPosition;

    private float _movement;

    private void Start()
    {
        startPosition = transform.position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (isPlayer1)
        {
            _movement = Input.GetAxisRaw("Mouse Y");
        }
        else
        {
            _movement = Input.GetAxisRaw("Vertical");
        }

        rb.velocity = new Vector2(rb.velocity.x, _movement * speed * Time.deltaTime);
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}
