using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class SelectManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI infoText;
    [SerializeField] TextMeshProUGUI classText;
    #region �̸�/����/���� ��...
    string[] trainNames = {"�ֱ�", "�Ϳ��", "������"};
    string[] trainInfo = {"�ſ� �Ϳ��� ��������� �׹��̸� ģ 7�� ���� ������ֽð� ������ֽð� �������߾�Ӵ�", "�����ʹ�", "�������"};
    string[] trainRole = {"����", "�ٵ�", "��"};
    #endregion
    void Start()
    {

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

