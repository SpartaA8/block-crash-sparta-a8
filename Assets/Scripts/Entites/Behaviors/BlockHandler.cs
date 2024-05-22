using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BlockHandler : MonoBehaviour
{
    [SerializeField]private BlockSO blockSO;
    private SpriteRenderer spriteRenderer;
    private int currentHp;

    private void Awake()
    {
        GameManager.Instance.OnFinishStageEvent += DestroyBlock;
    }

    public void BlockSpriteChange()
    {
        Sprite[] slicedSprites = Resources.LoadAll<Sprite>("Breakout-001-C");
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = slicedSprites[blockSO.blockSpriteColor];
    }

    public void SetBlockSO(BlockSO newBlockSO)
    {
        blockSO = newBlockSO;
        currentHp = blockSO.hp;
        BlockSpriteChange();
    }    

    public void TakeDamage(int damage)
    {

        if (!blockSO.isInvincible)
        {
            currentHp -= damage;
            if (currentHp == 0)
            {
                Destroy(gameObject);                
                ItemDataManager.Instance.SpawnItem(transform.position, blockSO.hp);
                GameManager.Instance.DestroyBlock(blockSO.score);
            }
        }
    }

    private void DestroyBlock()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnFinishStageEvent -= DestroyBlock;
    }
}
