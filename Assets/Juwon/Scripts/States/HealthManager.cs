using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //Hp가 들어가는 유닛에 넣기
    [SerializeField] private float curHealth;

    public float Health { get; set; }

    public float Damage { get; set; } = 0;

    //자신의 HP가 0이라면 비활성화
}