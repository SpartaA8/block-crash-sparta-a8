using UnityEngine;

[CreateAssetMenu(fileName = "StageSO", menuName = "ScriptObj/Stage", order = 3)]
public class StageSO : ScriptableObject
{
    [Header("Stage Info")]
    public int[] map;   
}
