using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour
{
    [SerializeField]private BlockSO blockSO;
    private SpriteRenderer spriteRenderer;

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
        BlockSpriteChange();
    }
}
