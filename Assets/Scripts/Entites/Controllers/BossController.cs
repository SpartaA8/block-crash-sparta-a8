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
        Debug.Log("애니메이션실행");
        while (true)
        {
            yield return new WaitForSeconds(4f);

            int randomValue = Random.Range(0, 4);
            if (randomValue == 0)
            {
                Debug.Log("어택1");
                animator.SetTrigger("Attack1");
            }
            else if (randomValue == 1)
            {
                Debug.Log("어택2");
                animator.SetTrigger("Attack2");
            }
            else if (randomValue == 2)
            {
                Debug.Log("어택3");
                animator.SetTrigger("Attack3");
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 공인지 확인
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("히트");
            animator.SetTrigger("BossHit");
        }
        // 플레이어와 충돌했는지 확인
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("플레이어킬");
            Destroy(collision.gameObject); // 플레이어 오브젝트를 파괴
        }
    }
}
