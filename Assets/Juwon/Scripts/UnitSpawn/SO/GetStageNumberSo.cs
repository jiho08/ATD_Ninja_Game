using UnityEngine;


[CreateAssetMenu(menuName = "SO/Stage/StageNumber")]
public class GetStageNumberSo : ScriptableObject
{
    public int stageNumber;
    public float timer;
    public bool[] isOpenStage;
    public bool isTutorial;
}