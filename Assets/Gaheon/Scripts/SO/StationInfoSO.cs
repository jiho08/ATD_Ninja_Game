using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "SO/OtherThings/StationImages")]
public class StationInfoSO : ScriptableObject
{
    public Sprite[] StationImages;
    public string[] stationNames;
    public int[] rewardResources;
    public UnitDataSO[] unitSO;
}
