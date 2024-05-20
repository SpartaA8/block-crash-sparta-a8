using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BallController : MonoBehaviour
{
    public float defaultSpeed;
    private Rigidbody2D rigidbody;
    private TrailRenderer trailRenderer;  
    private BlockSO blockSO;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();        
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(Mathf.Sign(rigidbody.velocity.x) * Mathf.Abs(defaultSpeed), rigidbody.velocity.y);
    }

    public void Copy()
    {
        GameObject rightBall = GameManager.Instance.CreateBalls();
        GameObject leftBall = GameManager.Instance.CreateBalls();

        Vector2 upwardDirection = new Vector2(0, 1);
        Vector2 rightDirection = Quaternion.Euler(0, 0, 45) * upwardDirection; // 오른쪽 방향으로 45도 회전
        Vector2 leftDirection = Quaternion.Euler(0, 0, -45) * upwardDirection; // 왼쪽 방향으로 45도 회전

        rightBall.transform.position = this.transform.position;
        leftBall.transform.position = this.transform.position;

        Rigidbody2D rightRb = rightBall.GetComponent<Rigidbody2D>();
        Rigidbody2D leftRb = leftBall.GetComponent<Rigidbody2D>();
        rightRb.velocity = rightDirection.normalized * rigidbody.velocity.magnitude;
        leftRb.velocity = leftDirection.normalized * rigidbody.velocity.magnitude;
    }

    public void Destroyed()
    {
        GameManager.Instance.ObjectPool.ReturnObject(this.gameObject);
        GameManager.Instance.DestroyBalls();
    }

    void OnCollisionEnter2D(Collision2D collision) //TODO ::  switch문으로 고치기
    {
        rigidbody.velocity = rigidbody.velocity.normalized * defaultSpeed;
        int bottomLayer = LayerMask.NameToLayer("Bottom");
        int blockLayer = LayerMask.NameToLayer("Block");
        int paddleLayer = LayerMask.NameToLayer("Paddle");

        if (collision.gameObject.layer == paddleLayer)
        {
            ProcessPaddleCollision(collision);
        }
        if (collision.gameObject.layer == blockLayer)
        {
            ProcessBlockCollision(collision);
        }
        if (collision.gameObject.layer == bottomLayer)
        {
            //Destroyed();
        }
    }

    private void ProcessPaddleCollision(Collision2D collision)
    {
        Vector2 collisionPoint = collision.contacts[0].point; // 패들에 어느위치에 충돌이 일어났는지 확인 하기위한 Vector
        Vector2 paddleCenter = collision.transform.position; // 패들 중심 가져오기위한 Vector

        // 충돌 지점이 패들 중심보다 왼쪽에 있는지 확인
        bool isLeftCollision = collisionPoint.x < paddleCenter.x;

        // X축 방향의 속도를 왼쪽 또는 오른쪽으로 반전
        float direction = isLeftCollision ? -1f : 1f;
        rigidbody.velocity = new Vector2(direction * Mathf.Abs(rigidbody.velocity.x), rigidbody.velocity.y);
    }
    private void ProcessBlockCollision(Collision2D collision)
    {
        int blockID = collision.gameObject.layer;
        BlockSO blockSO = BlockDataManager.GetInstance().GetData(blockID);

        if (blockSO != null)
        {
            blockSO.hp--; // 충돌한 블록의 HP 감소
            Debug.Log("현재 HP: " + blockSO.hp);

            if (blockSO.hp <= 0)
            {
                // 블록의 HP가 0 이하이면 블록을 파괴
                Destroy(collision.gameObject);
            }
        }
        else
        {
            Debug.Log("blockSO은 null");
        }
    }

    private bool IsLayerMatched(int value, int layer)
    {
        return value == (value | 1 << layer);
    }
}
