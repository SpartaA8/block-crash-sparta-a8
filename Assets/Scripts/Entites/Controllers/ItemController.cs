using UnityEngine;

public class ItemController : MonoBehaviour
{
    public ItemSO SoItem;

    public void ItemDestroy()
    {
        Destroy(gameObject);
    }
}