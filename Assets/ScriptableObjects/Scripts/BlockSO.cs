using UnityEngine;

[CreateAssetMenu(fileName = "BlockSO", menuName = "ScriptObj/Block", order = 2)]
public class BlockSO : ScriptableObject
{
    [Header("Block Info")]
    public int level;    
    public int hp;
    public bool isInvincible;
    public int score;
}
