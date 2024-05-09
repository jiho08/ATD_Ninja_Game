using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.Events;
using TMPro;

public class SelectManager : MonoBehaviour
{
    #region 받아오기
    [Header("Info")]
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI descText;
    [SerializeField] TextMeshProUGUI roleText;


    [Header("Level SO")]
    [SerializeField] UnitLevelUpSO ktxLevelSO;
    [SerializeField] UnitLevelUpSO mghLevelSO;
    [SerializeField] UnitLevelUpSO line1LevelSO;
    public UnitLevelUpSO selectedUnitLevel;

    [Header("기차 스프라이트")]
    [SerializeField] SpriteLibrary trainHeadAnimation;
    [SerializeField] SpriteLibrary[] trainBodyAnimation;
    [SerializeField] SpriteRenderer trainHead;
    [SerializeField] SpriteRenderer[] trainBody;
    public BoxCollider2D[] trainCollider;

    [Header("SO")]
    public UnitDataSO ktxSO;
    public UnitDataSO mghSO;
    public UnitDataSO line1SO;
    public UnitDataSO selectedSO; //바에서도 사용 할 듯 

    [Header("PriceSO")]
    [SerializeField] UnitPriceSO ktxPriceSO;
    [SerializeField] UnitPriceSO mghPriceSO;
    [SerializeField] UnitPriceSO line1PriceSO;

    public UnitPriceSO selectedPriceSO;

    [SerializeField] UnityEvent OnSelectChanged;
    #endregion

    void Start()
    {
        Selecting();
    }

    public void Selecting()
    {
        ChangeValue();

        nameText.text = selectedSO.TrainName;
        descText.text = selectedSO.TrainDesc;
        roleText.text = selectedSO.TrainRole;

        trainHeadAnimation.spriteLibraryAsset = selectedSO.TrainAnimation;
        trainBodyAnimation[0].spriteLibraryAsset = selectedSO.TrainAnimation;
        trainBodyAnimation[1].spriteLibraryAsset = selectedSO.TrainAnimation;

        trainCollider[0].size = trainHead.bounds.size;
        trainCollider[1].size = trainBody[0].bounds.size;
        trainCollider[2].size = trainBody[0].bounds.size;

        OnSelectChanged.Invoke();
    }

    public void ChangeValue()
    {
        selectedSO.Hp = selectedUnitLevel.Hp[selectedSO.level - 1];
        selectedSO.Atk = selectedUnitLevel.Atk[selectedSO.level - 1];
        selectedSO.Speed = selectedUnitLevel.Speed[selectedSO.level - 1];

    }
    public void KTX()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);

        selectedSO = ktxSO;
        selectedUnitLevel = ktxLevelSO;
        selectedPriceSO = ktxPriceSO;
        selectedPriceSO = ktxPriceSO;
        Selecting();
    }
    public void MGH()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);

        selectedSO = mghSO;
        selectedUnitLevel = mghLevelSO;
        selectedPriceSO = mghPriceSO;
        Selecting();
    }
    public void Line1()
    {
        AudioManager.Instance.PlaySfx(AudioManager.Sfx.Btn);

        selectedSO = line1SO;
        selectedUnitLevel = line1LevelSO;
        selectedPriceSO = line1PriceSO;
        Selecting();
    }

}

