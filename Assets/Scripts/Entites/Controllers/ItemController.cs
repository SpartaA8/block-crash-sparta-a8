using UnityEngine;

public class ItemController : MonoBehaviour
{
    public ItemSO SoItem;

    private void OnEnable()
    {
        GameManager.Instance.OnFinishStageEvent += ItemDestroy;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnFinishStageEvent -= ItemDestroy;
    }

    public void SetItemSO(ItemSO itemSO)
    {
        SoItem = itemSO;
    }

    public void ItemDestroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            Destroy(gameObject);
        }
    }
}