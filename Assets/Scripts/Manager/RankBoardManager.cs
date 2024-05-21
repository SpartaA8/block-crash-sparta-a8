using System.Collections.Generic;
using UnityEngine;

public class RankBoardManager : MonoBehaviour
{
    public static RankBoardManager Instance;

    private List<RankInfo> rankList = new List<RankInfo>();
    private int maxRankNum = 10;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }        
    }
    private void Start()
    {
        
    }
}