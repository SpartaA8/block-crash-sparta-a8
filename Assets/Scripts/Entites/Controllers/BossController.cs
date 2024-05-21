using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(BossAttackRoutine());

    }

    private IEnumerator BossAttackRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);

            int randomValue = Random.Range(0, 4);
            if (randomValue == 0)
            {
                animator.SetTrigger("Attack1");
            }
            else if (randomValue == 1)
            {
                animator.SetTrigger("Attack2");
            }
            else if (randomValue == 2)
            {
                animator.SetTrigger("Attack3");
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            animator.SetTrigger("BossHit");
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
