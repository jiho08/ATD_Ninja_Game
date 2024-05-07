using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //Hp가 들어가는 유닛에 넣기
    [SerializeField] private float _curHealth = 1;

    public delegate void RepairEnemyCool(int value);
    public delegate void RepairUnitCool();
    
    public RepairUnitCool OnUnitRepairCool;
    public RepairEnemyCool OnEnemyRepairCool;

    [SerializeField] private int unitCode;
    public bool[] isOnEntity; //0:unit, 1:Enemy, 2:tower

    public float Health
    {
        get => _curHealth;
        set
        {
            _curHealth = value;
            
            if(isOnEntity[2]) return;
            
            if (_curHealth <= 0 && isOnEntity[0])
            {
                OnUnitRepairCool?.Invoke();
                gameObject.SetActive(false);
            }
            else if (_curHealth <= 0 && isOnEntity[1])
            {
                OnEnemyRepairCool?.Invoke(unitCode);
                gameObject.SetActive(false);
            }
            
        }
    }

    public float Damage { get; set; }

    //자신의 HP가 0이라면 비활성화
    
}