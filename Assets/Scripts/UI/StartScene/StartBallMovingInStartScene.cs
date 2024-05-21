using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartBallMovingInStartScene : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public GameObject ball;
    public int i = 0;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(BallMoving());
    }

    IEnumerator BallMoving()
    {
        rigidbody.gravityScale = 0f;
        rigidbody.velocity = (Vector3.down + Vector3.right) * 7f;
        yield break;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.collider.gameobject.comparetag("wall"))
        //{
        //    ball.transform.rotation *= quaternion.euler(0, 0, 45);


        //    switch(i % 2)
        //    {
        //        case 0:
        //            rigidbody.addforce(new vector2(transform.rotation.z, 0), forcemode2d.impulse);
        //            i++;
        //            break;
        //        case 1:
        //            rigidbody.addforce(new vector2(-transform.rotation.z, 0), forcemode2d.impulse);
        //            i++;
        //            break;
        //    }
            
        //}
    }
}
