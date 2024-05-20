using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameObject[] players = new GameObject[2];

    public event Action OnCopyBallEvent;

    private int highScore;
    private int currentScore;
    private int blockCount;
    private int stageLevel = 1;
    private bool isMulti = true;
    private int life;
    public int ballCount = 1;

    public ObjectPool ObjectPool { get; private set; }

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;

        BlockDataManager.GetInstance();
    }

    private void Start()
    {
        ObjectPool = GetComponent<ObjectPool>();
        players[0] = GameObject.Find("Player").transform.GetChild(0).gameObject;
        players[1] = GameObject.Find("Player").transform.GetChild(1).gameObject;
        players[1].SetActive(isMulti);
        StartStage(stageLevel);
    }    

    private void StartStage(int stageLevel)
    {
        ResetPlayerPos();
        GameObject obj = CreateBalls();
        obj.transform.parent = players[0].transform;
        obj.transform.position = new Vector3(0, -3.2f, 0);        
    }

    private void ResetPlayerPos()
    {  
        Vector3 startPos = isMulti ? Vector3.left * 2 : Vector3.zero;
        players[0].transform.position += startPos;
        if (isMulti) players[1].transform.position -= startPos;
    }

    // 블록 파괴 시 
    public void DestroyBlock(int score)
    {   
        if (--blockCount == 0) StartStage(++stageLevel);
    }

    // 목숨 추가 아이템
    public void AddLife()
    {
        life++;
    }

    // 볼 복사 아이템
    public GameObject CreateBalls()
    {
        GameObject obj = ObjectPool.SpawnFromPool("Ball");
        BallController ball = obj.GetComponent<BallController>();
        OnCopyBallEvent += ball.Copy;

        return obj;
    }

    private void CallCopyBallEvent()
    {
        OnCopyBallEvent?.Invoke();
    }

    public void Copyballs()
    {
        CallCopyBallEvent();
        ballCount *= 3;
    }

    public void DestroyBalls()
    {
        if (--ballCount == 0) GameOver();
    }

    private void GameOver()
    {
        
    }    
}
