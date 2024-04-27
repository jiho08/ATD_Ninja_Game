using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject hpBarObj;
    private float _maxHpValue = 100;
    private float _curHpValue = 100;
    [SerializeField] private HealthManager health;

    private void Start() {
        _maxHpValue = health.Health;
    }

    void LateUpdate()
    {
        _curHpValue = health.Health;
        //만약 맞았다면 if로 넣기
        hpBarObj.transform.localScale = new Vector3(_curHpValue / _maxHpValue * 5f, 0.5f, 0.5f); //healthManager에서 최대체력과 현재 체력 넣기
        if(_curHpValue <= 0) health.Health = 0;
    }
}
