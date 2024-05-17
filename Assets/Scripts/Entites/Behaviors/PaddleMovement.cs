using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private PlayerController controller;
    private Rigidbody2D rigidbody;

    private int size;
    private float speed = 2f;

    private void Awake()
    {
        controller = GetComponentInParent<PlayerController>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    public void Move(float input)
    {
        Vector2 direction = new Vector2(input, 0);
        rigidbody.velocity = direction * speed;
    }
}

