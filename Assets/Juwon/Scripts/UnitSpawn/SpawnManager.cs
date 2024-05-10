using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private PoolManager unitPool;
    [SerializeField] private PoolManager enemyPool;

    [SerializeField] private UIInputManager[] uiInputM;
    [SerializeField] private OwningUnitSO owning;

    [SerializeField] private UnitDataSO[] unitData; //유닛에 레벨에 맞게 스탯 가져오기
    [SerializeField] private EnemyStatsSo enemyData;

    public NotifyValue<int> currentUnitNum;

    //[SerializeField] private Transform[] unitSpawnPos; //스폰 위치 3개 관리
    [SerializeField] private Transform[] enemySpawnPos;

    private readonly int[] _defaultSpawnCounts = new int[10]; //유닛 수만큼 넣기 (0 : 무궁화, 1 : 무언가, 2 : 등등)
    private int[] _getSpawnCounts = new int[10]; //소환된 유닛 수만큼 넣기 (0 : 무궁화, 1 : 무언가, 2 : 등등)

    public int[] GetSpawnCounts
    {
        get => _getSpawnCounts;
        set => _getSpawnCounts = value;
    }

    private HealthManager _unitHealth; //생성한 Unit의 HealthManager
    private HealthManager _enemyHealth; //생성한 Enemy의 HealthManager
    private Coroutine _inCorout;

    private void Start()
    {
        currentUnitNum.Value = _defaultSpawnCounts[0];
        uiInputM[0].OnUnitNumChange += HandleUnitSpawn;
        uiInputM[1].OnUnitNumChange += HandleUnitSpawn;
        uiInputM[2].OnUnitNumChange += HandleUnitSpawn;

        if (owning.OwningMGH) uiInputM[0].gameObject.SetActive(true);
        if (owning.OwningKTX) uiInputM[1].gameObject.SetActive(true);
        if (owning.OwningLine1) uiInputM[2].gameObject.SetActive(true);
        
    }

    //원하는 유닛과 위치 생성
    public GameObject UnitSpawn(int value)
    {
        if(_getSpawnCounts[value] >= _defaultSpawnCounts[value]) 
        {
            AudioManager.Instance.PlaySfx(AudioManager.Sfx.Warning);
            return null; //정해진 수보다 많아지면 리턴
        }
        
        GameObject unit = unitPool.Get(value);
        //unit.transform.position = unitSpawnPos[pos-1].position; //정해진 소환할 위치에 소환(우선 정함)
        _unitHealth = unit.GetComponent<HealthManager>();
        _unitHealth.Health = unitData[value].Hp; //HP설정
        _unitHealth.Damage = unitData[value].Atk; //데미지 설정
        PlayerUnit unitP = unit.GetComponent<PlayerUnit>(); //Speed 설정
        unitP._maxSpeed = unitData[value].Speed;
        unitP._trainLength = unitData[value].length;

        this._unitHealth.OnUnitRepairCool += HandleRepairCoolTime;
        
        return unit;
    }

    //원하는 적과 위치 생성
    public GameObject EnemySpawn(int value, int pos)
    {
        GameObject enemy = enemyPool.Get(value);
        _enemyHealth = enemy.GetComponent<HealthManager>();
        EnemyScript enemyS = enemy.GetComponent<EnemyScript>();
        _enemyHealth.Health = enemyData.enemysData[value].hp; //HP설정
        enemyS._maxSpeed = enemyData.enemysData[value].speed; //speed 설정
        enemyS._GetDamage = enemyData.enemysData[value].atk;


        enemy.transform.position = enemySpawnPos[pos-1].position;
        
        return enemy;
    }
    
    //유닛이 부셔지고 일정 시간이 지나면 다시 생성할 수 있게 변경
    private void HandleRepairCoolTime(int value)
    {
        this._unitHealth.OnUnitRepairCool -= HandleRepairCoolTime;
        
        _inCorout = StartCoroutine(UnitCool(value));
    }

    private void HandleUnitSpawn(int value)
    {
        _getSpawnCounts[value]++;
        currentUnitNum.Value = GetSpawnCounts[value];
    }
    private IEnumerator UnitCool(int value)
    {
        yield return new WaitForSeconds(10f);

        _getSpawnCounts[value]--;
        currentUnitNum.Value = GetSpawnCounts[value];

        StopCoroutine(_inCorout);
    }

    public void SetDefaultCounts(int value, int count) //value의 번호에 유닛 제한수를 count로 제한
    {
        _defaultSpawnCounts[value] = count;
    }
    
    public int GetDefaultCounts(int value) //value의 번호에 유닛 제한수를 count로 제한
    {
        return _defaultSpawnCounts[value];
    }
}
