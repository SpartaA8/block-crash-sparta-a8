using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataManager : MonoBehaviour
{
    public static ItemDataManager Instance;
    private Dictionary<int, ItemSO> itemDictionary;

    [SerializeField] private ItemSO ItemLIFESO;
    [SerializeField] private ItemSO ItemSIZESO;
    [SerializeField] private ItemSO ItemSPEEDSO;
    [SerializeField] private ItemSO ItemCOPYSO;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SetItemDictionary();
        }
    }

    public void SetItemDictionary()
    {
        itemDictionary = new Dictionary<int, ItemSO>
        {
            {1, ItemLIFESO},
            {2, ItemSIZESO},
            {3, ItemSPEEDSO},
            {4, ItemCOPYSO}
        };
    }

    public ItemSO GetData(int id)
    {
        if (id == 0 || !itemDictionary.ContainsKey(id))
        {
            return null;
        }
        return itemDictionary[id];
    }
}
    
    