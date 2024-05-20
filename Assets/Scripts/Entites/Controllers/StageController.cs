using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    StageDataManager stageDataManager;
    BlockDataManager blockDataManager;
    public GameObject block;

    int stageNum;

    private void Awake() //초기설정, 스테이지1 불러옴
    {
        //stageDataManager = StageDataManager.GetInstance();
        //blockDataManager = BlockDataManager.GetInstance();        
    }


    public void StartStage(int stageNum) //현재 스테이지의 맵 데이터를 가져와서 블록을 생성
    {
        int[,] currentMap = StageDataManager.GetInstance().GetStageMaps(stageNum);

        for (int i = 0; i < currentMap.GetLength(0); i++)
        {
            for (int j = 0; j < currentMap.GetLength(1); j++)
            {
                int blockId = currentMap[i, j];
                BlockSO blockData = BlockDataManager.GetInstance().GetData(blockId);

                if (blockData != null)
                {
                    Vector3 position = new Vector3(j * 0.72f + -3.595f, -i * 0.39f + 3.45f, 0);
                    GameObject newBlock = Instantiate(block, position, Quaternion.identity);
                    newBlock.transform.parent = transform;
                    newBlock.GetComponent<BlockHandler>().SetBlockSO(blockData);
                }
            }
        }
    }
}
