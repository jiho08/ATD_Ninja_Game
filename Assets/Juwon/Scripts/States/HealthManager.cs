using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //Hp가 들어가는 유닛에 넣기
    [SerializeField] private float curHealth = 1;

    public float Health
    {
        get => curHealth;
        set
        {
            curHealth = value;
            
            if (curHealth <= 0)
            {
                gameObject.SetActive(false);
            }
            
        }
    }

    public float Damage { get; set; }

    //자신의 HP가 0이라면 비활성화
    
}