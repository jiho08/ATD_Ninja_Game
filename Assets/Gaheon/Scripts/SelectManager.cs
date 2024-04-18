using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] TextMeshProUGUI classText;
    #region 이름/정보/역할 등...
    string[] trainNames = {"KTX", "무궁화호", "1호선"};
    string[] trainInfo = {"매우 귀엽고 사랑스러운 테바이를 친 7명 제발 사랑해주시고 보든어주시고 제발제발어머니", "연어초밥", "간장게장"};
    string[] trainRole = {"딜러", "탱커", "원거리 딜러"};
    #endregion
    void Start()
    {
        Selecting(0);
    }

    void Update()
    {
        
    }

    void Selecting(int trainNum)
    {
        nameText.text = trainNames[trainNum];
        infoText.text = trainInfo[trainNum];
        classText.text = trainRole[trainNum];
    }
    public void TestTrain()
    {
        Selecting(0);
    }
    public void TestTrain1()
    {
        Selecting(1);
    }
    public void TestTrain2()
    {
        Selecting(2);
    }

}

