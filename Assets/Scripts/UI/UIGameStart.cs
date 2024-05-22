using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameStart : MonoBehaviour
{
    private TextMeshProUGUI stageNumText;
    

    private void Awake()
    {
        stageNumText = GetComponentsInChildren<TextMeshProUGUI>()[0];        
    }

    private void OnEnable()
    {
        GameManager.Instance.OnFinishStageEvent += ChangeScoreUI;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnFinishStageEvent -= ChangeScoreUI;
    }

    private void ChangeScoreUI()
    {
        string str = GameManager.Instance.StageLevel.ToString();
        stageNumText.text = "Stage " + str + "\nGame Start";
    }
}
