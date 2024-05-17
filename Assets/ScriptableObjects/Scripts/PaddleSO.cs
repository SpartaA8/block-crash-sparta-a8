using UnityEngine;

[CreateAssetMenu(fileName = "PaddleSO", menuName = "ScriptObj/Paddle", order = 1)]
public class PaddleSO : ScriptableObject
{
    [Header("Paddle Info")]
    public int size;
    public float score;    
}
