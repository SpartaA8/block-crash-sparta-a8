using UnityEngine;

[CreateAssetMenu(fileName = "ScoreSO", menuName = "ScriptObj/Score", order = 0)]
public class ScoreSO : ScriptableObject
{
    [Header("Score Info")]
    public string name;
    public int score;    
}
