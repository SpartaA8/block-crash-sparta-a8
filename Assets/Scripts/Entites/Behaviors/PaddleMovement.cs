using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private PlayerController controller;
    private Rigidbody2D rigidbody;

    private int size;
    private float speed = 2f;
    private bool isCollision = false;
    private Vector3 direction;

    private void Awake()
    {
        controller = GetComponentInParent<PlayerController>();
        rigidbody = GetComponent<Rigidbody2D>();        
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
        controller.OnFireEvent += Fire;        
    }

    private void FixedUpdate()
    {
        if (isCollision) rigidbody.velocity = Vector3.zero;
        else rigidbody.velocity = direction;
    }

    public void Move(float input)
    {
        //isCollision = false;
        direction = new Vector2(input, 0);
        direction = direction * speed;
    }

    public void Fire()
    {
        GameManager.Instance.Copyballs();
    }

    //private bool CheckCollisionByRaycast()
    //{

    //}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (IsLayerMatched(LayerMask.GetMask("Player") | LayerMask.GetMask("Wall"), collider.gameObject.layer))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0);
            if (hit.collider != null) isCollision = true;
            else isCollision = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (IsLayerMatched(LayerMask.GetMask("Player") | LayerMask.GetMask("Wall"), collider.gameObject.layer))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 0);
            if (hit.collider != null) isCollision = true;
            else isCollision = false;
        }
    }    

    private bool IsLayerMatched(int value, int layer)
    {
        return value == (value | 1 << layer);
    }
}

