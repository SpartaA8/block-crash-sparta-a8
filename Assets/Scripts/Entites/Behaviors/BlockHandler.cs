using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BlockHandler : MonoBehaviour
{
    [SerializeField]private BlockSO blockSO;
    [SerializeField] private GameObject itemPrefab; // 아이템 생성 Prefab
    private SpriteRenderer spriteRenderer;
    private int currentHp;

    private void Awake()
    {
        
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
            if (currentHp <= 0)
            {
                Destroy(gameObject);
                SpawnItem();
            }
        }
        
    }
    private void SpawnItem()
    {
        int randomIndex = Random.Range(1, 5); // 1부터 4 사이의 랜덤한 값을 선택
        ItemSO itemData = ItemDataManager.Instance.GetData(randomIndex);
        if (itemData != null && itemPrefab != null)
        {
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }
    }
    private void OnDestroy()
    {
        GameManager.Instance.DestroyBlock(blockSO.score);
    }
}
