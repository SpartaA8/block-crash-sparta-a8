using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameObject[] players = new GameObject[2];

    private int highScore;
    private int currentScore;
    private int blockCount;
    private int stageLevel = 1;
    private bool isMulti = false;
    private int life;

    public ObjectPool ObjectPool { get; private set; }

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }

    private void Start()
    {
        ObjectPool = GetComponent<ObjectPool>();
        players[0] = GameObject.Find("Player").transform.GetChild(0).gameObject;
        players[1] = GameObject.Find("Player").transform.GetChild(1).gameObject;
        players[1].SetActive(isMulti);
        StartStage();
    }    

    private void StartStage()
    {
        ResetPlayerPos();        
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
        if (--blockCount == 0) GameOver();
    }

    // 목숨 추가 아이템
    public void AddLife()
    {
        life++;
    }

    // 볼 복사 아이템
    public void CreateBalls()
    {

    }

    private void GameOver()
    {
        
    }
}
