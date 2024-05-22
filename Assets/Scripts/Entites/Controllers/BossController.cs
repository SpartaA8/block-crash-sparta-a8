using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    private Animator animator;
    private int ChangeBossIndex;
    private BossHandler bossHandler;
    private Coroutine CurrentPattern;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        bossHandler = GetComponent<BossHandler>();
    }

    public void Start()
    {
        
        ChangeBossIndex = animator.GetLayerIndex("ChangeBoss Layer");
        CurrentPattern = StartCoroutine(BossAttackPhase1());
        bossHandler.BossPhase2 += BossChangePattern;
    }

    private IEnumerator BossAttackPhase1()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);

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

    private IEnumerator BossAttackPhase2()
    {
        animator.SetLayerWeight(ChangeBossIndex, 1);
        animator.SetTrigger("ChangeBoss");
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(5f);
        Time.timeScale = 1f;

        while (true)
        {

            yield return new WaitForSeconds(4f);

            int randomValue = Random.Range(0, 4);
            if (randomValue == 0)
            {
                //animator.SetTrigger("nell");
            }
            else if (randomValue == 1)
            {
                //animator.SetTrigger("");
            }
            else if (randomValue == 2)
            {
                //animator.SetTrigger("");
            }
        }
    }

    private void BossChangePattern()
    {
        StopCoroutine(CurrentPattern);
        CurrentPattern = StartCoroutine(BossAttackPhase2());
    }
}
