using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Copy()
    {
        GameObject rightBall = GameManager.Instance.CreateBalls();
        GameObject leftBall = GameManager.Instance.CreateBalls();
        
        rightBall.transform.position = this.transform.position;
        leftBall.transform.position = this.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsLayerMatched(LayerMask.GetMask("Bottom"), collision.gameObject.layer))
        {
            GameManager.Instance.ObjectPool.ReturnObject(this.gameObject);
            GameManager.Instance.DestroyBalls();
        }
    }

    private bool IsLayerMatched(int value, int layer)
    {
        return value == (value | 1 << layer);
    }
}
