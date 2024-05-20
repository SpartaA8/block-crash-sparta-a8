using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private PlayerController controller;
    private Rigidbody2D rigidbody;    

    private float size;
    private float speed = 2f;    
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

    private void Update()
    {        
        rigidbody.velocity = direction;
    }

    public void Move(float input)
    {
        if (input == 0) rigidbody.constraints |= RigidbodyConstraints2D.FreezePositionX;
        else rigidbody.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        direction = new Vector2(input, 0);
        direction = direction * speed;     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //오브젝트 충돌 후 효과 적용
        if (collision.gameObject.layer == 9)
        {
            ItemController collisionController = collision.gameObject.GetComponent<ItemController>();
            //아이템 타입 분별 및 효과 적용
            ApplyItem(collisionController.SoItem.itemType);
            //아이템 먹은 후 파괴
            Destroy(collision.gameObject);
        }
    }

    public void Fire()
    {
        GameManager.Instance.Copyballs();
    }

    public void ApplyItem(EItemType itemType)
    {
        if (itemType == EItemType.SIZE)
        {
            ChangeSize();
        }
        else if (itemType == EItemType.SPEED)
        {
            ChangeSpeed();
        }
        else if (itemType == EItemType.LIFE)
        {
            GameManager.Instance.AddLife();
        }
        else if (itemType == EItemType.COPY)
        {
            GameManager.Instance.Copyballs();
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

