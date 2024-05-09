using System;
using Cinemachine;
using UnityEngine;

public class StageChange : MonoBehaviour
{
    [SerializeField] private Transform[] enemySpawnPos;
    [SerializeField] private GameObject[] stageMapObjs;
    [SerializeField] private CinemachineConfiner2D cinema;
    [SerializeField] private PolygonCollider2D[] colP;
    [SerializeField] private GetStageNumberSo stageNum;
}

