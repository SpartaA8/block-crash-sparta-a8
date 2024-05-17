using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int highScore;
    private int currentScore;
    private int blockCount;
    private int stageLevel;

    public ObjectPool ObjectPool { get; private set; }

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
        
        ObjectPool = GetComponent<ObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 블록 파괴 시 
    public void DestroyBlock(int score)
    {

    }
        

    // 목숨 추가 아이템
    public void AddLife()
    {

    }

    // 볼 복사 아이템
    public void CreateBalls()
    {

    }
}
