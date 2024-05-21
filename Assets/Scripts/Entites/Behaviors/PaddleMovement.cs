using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private PlayerController controller;
    private Rigidbody2D rigidbody;
    private FixedJoint2D joint;

    private float size;
    private float speed = 5f;    
    private Vector3 direction;
    private bool isHold;

    private void Awake()
    {
        controller = GetComponentInParent<PlayerController>();
        rigidbody = GetComponent<Rigidbody2D>();   
        joint = GetComponent<FixedJoint2D>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
        controller.OnFireEvent += Fire;        
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = direction * speed;
        Debug.Log("update");
    }

    public void Move(float input)
    {
        if (input == 0)
        {
            rigidbody.constraints |= RigidbodyConstraints2D.FreezePositionX;
            Debug.Log("stop");
        }
            
        else
        {
            rigidbody.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
            Debug.Log("move");
        }
            
        direction = new Vector2(input, 0);        
    }

    public void Fire()
    {
        if (isHold) ShootBall();
        else CheckHold();
    }

    private void CheckHold()
    {
       
    }

    private void ShootBall()
    {        
        isHold = false;
        float posX = joint.anchor.x < 0 ? 1f : -1f;        
        BallController ball = joint.connectedBody.gameObject.GetComponent<BallController>();
        joint.connectedBody = null;
        joint.enabled = false;
        ball.Shoot(posX);        
    }

    public void HoldBall(GameObject obj, float posX)
    {
        Rigidbody2D ball = obj.GetComponent<Rigidbody2D>();
        isHold = true;
        float posY = -3.97f;
        obj.transform.position = new Vector2(posX, posY);
        joint.enabled = true;
        joint.connectedBody = ball;
        obj.GetComponent<BallController>().Catched();
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

