using UnityEngine;
using UnityEngine.Serialization;

public class HealthManager : MonoBehaviour
{
    //Hp가 들어가는 유닛에 넣기

    private readonly float _maxHealth = 10f;
    [FormerlySerializedAs("_curHealth")] [SerializeField] private float curHealth;

    public float Health
    {
        get => curHealth;
        set => curHealth = value;
    }


    private void Start()
    {
        curHealth = _maxHealth;
    }

    public void Damage(float value)
    {
        curHealth -= value;
    }

    //자신의 HP가 0이라면 비활성화
}