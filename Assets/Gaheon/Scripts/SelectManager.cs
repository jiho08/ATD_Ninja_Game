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
    #region �̸�/����/���� ��...
    string[] trainNames = {"KTX", "����ȭȣ", "1ȣ��"};
    string[] trainInfo = {"�ſ� �Ϳ��� ��������� �׹��̸� ģ 7�� ���� ������ֽð� ������ֽð� �������߾�Ӵ�", "�����ʹ�", "�������"};
    string[] trainRole = {"����", "��Ŀ", "���Ÿ� ����"};
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

