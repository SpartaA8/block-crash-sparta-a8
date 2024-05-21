using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHandler : MonoBehaviour
{
    [SerializeField] private BlockSO blockSO;
    private int currentHp;

    public void SetBossSO(BlockSO newBlockSO)
    {
        blockSO = newBlockSO;
        currentHp = blockSO.hp;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
