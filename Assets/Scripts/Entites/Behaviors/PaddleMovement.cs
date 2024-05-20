using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private PlayerController controller;
    private Rigidbody2D rigidbody;
    public GameObject Player1;
    private GameManager gameManager;

    private float size;
    public float speed = 2f;

    private void Awake()
    {
        controller = GetComponentInParent<PlayerController>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //오브젝트 충돌 후 효과 적용
        if(collision.gameObject.layer == 9)
        {
            ItemController collisionController = collision.gameObject.GetComponent<ItemController>();
            //아이템 타입 분별 및 효과 적용
            ApplyItem(collisionController.SoItem.itemType);
            //아이템 먹은 후 파괴
            Destroy(collision.gameObject);
        }
    }

    public void Move(float input)
    {
        Vector2 direction = new Vector2(input, 0);
        rigidbody.velocity = direction * speed;
    }

    public void Shoot(float input) 
    {

    }

    public void ApplyItem(EItemType itemType)
    {
        if(itemType == EItemType.SIZE)
        {
            ChangeSize();
        }
        else if(itemType == EItemType.SPEED)
        {
            ChangeSpeed();
        }
        else if(itemType == EItemType.LIFE)
        {
            gameManager.AddLife();
        }
        else if (itemType == EItemType.COPY)
        {

        }
    }

    public void ChangeSize()
    {
        //실제로 스케일에서 적용이 안됨
        float randomsize = Random.Range(-1f, 2f);

        size += randomsize;

    }

    public void ChangeSpeed()
    {
        float changespeed = Random.Range(-2f, 3f);

        speed += changespeed;
    }

}

