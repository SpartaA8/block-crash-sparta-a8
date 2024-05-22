using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHandler : MonoBehaviour
{
    private Animator animator;
    public event Action BossPhase2;
    [SerializeField] private BlockSO bossBlockSO;
    private int currentBossHp;
    private int hitLayerIndex;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        hitLayerIndex = animator.GetLayerIndex("Hit Layer");
        currentBossHp = bossBlockSO.hp;
    }

    public void TakeDamage(int damage)
    {
        currentBossHp -= damage;

        animator.SetLayerWeight(hitLayerIndex, 1);
        animator.SetTrigger("BossHit");

        if (currentBossHp == 0)
        {
            Destroy(gameObject);
        }
        else if (currentBossHp == 50)
        {
            BossPhase2?.Invoke();
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance.DestroyBlock(bossBlockSO.score);
    }
}