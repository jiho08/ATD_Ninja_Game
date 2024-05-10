using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Cinemachine;

public class UIInputManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler //,IDropHandler
{
    [FormerlySerializedAs("UnitCode")] public int unitCode; //진짜 유닛
    private GameObject Clone; //임시로 유닛 담을거

    public delegate void UnitSpawnNumChange(int value);

    public UnitSpawnNumChange OnUnitNumChange;

    private BoxCollider2D collider; // 유닛의 콜라이더 


    private PlayerUnit UnitMovemate2; // 유닛의 움직임 스크립트
    [SerializeField]
    private SpawnManager spawnM; // 유닛 소환 스크립트
    private AttackCollsion attCollsion;//유닛 근접 공격 콜라이더 스크립트
    private BoxCollider2D attCollider;//유닛 근접 공격 콜라이더
    private PlayerADUnit adAtt; //원거리 유닛 공격 스크립트
    [SerializeField] private Image coolTimeImage;

    private bool isAD; //근접 공격유닛인가 아닌가
    private bool isDragStarte = false;

    private SpriteRenderer _cloneRenderer; //유닛의 색변경을 위한 스프라이트 렌더러


    private Vector3 targetPosition; // 유닛의 마우스 포인터 따라가게 하기위한 뷰포인터

    [SerializeField] private float maxCoolTime;
    private float coolTime;
    private bool isCoolTime;
    
    private void Start()
    {
        coolTime = 0;
        isCoolTime = false;
        isDragStarte = false;
    }
    private void Update()
    {
        coolTimeImage.fillAmount = coolTime / maxCoolTime;
        if (coolTime > 0)
        {
            coolTime -= Time.deltaTime;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isDragStarte) return;
        if (!isCoolTime)
        {
            isDragStarte = true;
            Clone = spawnM.UnitSpawn(unitCode);

            if (Clone == null || isCoolTime) return;

            _cloneRenderer = Clone.GetComponentInChildren<SpriteRenderer>();
            UnitMovemate2 = Clone.GetComponent<PlayerUnit>();
            collider = Clone.GetComponent<BoxCollider2D>();

            if (Clone.gameObject.GetComponent<PlayerADUnit>() != null)
            {
                isAD = true;
                adAtt = Clone.GetComponent<PlayerADUnit>();
                adAtt.enabled = false;
            }
            else if (Clone.gameObject.GetComponent<PlayerADUnit>() == null)
            {
                isAD = false;
                attCollsion = Clone.transform.GetChild(0).GetChild(1).GetComponent<AttackCollsion>();
                attCollider = Clone.transform.GetChild(0).GetChild(1).GetComponent<BoxCollider2D>();
                attCollsion.enabled = false;
                attCollider.enabled = false;
            }

            Color32 c = _cloneRenderer.color;
            _cloneRenderer.color = new Color32(c.r, c.g, c.b, 100);

            UnitMovemate2.enabled = false;

            collider.enabled = false;
        }
        

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragStarte) return;
        if (!isCoolTime)
        {
            if (Clone == null) return;

            targetPosition = Camera.main.ScreenToWorldPoint(eventData.position);

            Clone.transform.position = new Vector3(targetPosition.x, targetPosition.y, 0);
            //transform.position = new Vector3(eventData.position.x, eventData.position.y, 0);
            //Debug.Log(eventData);
        }
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isDragStarte) return;
        if (!isCoolTime)
        {
            isDragStarte = false;
            if (Clone == null)
            {
                //Debug.Log("생성 안돼야함");
                return;
            }

            if (RailInput.onRail)
            {
                collider.enabled = true;
                UnitMovemate2.enabled = true;
                Color32 c = _cloneRenderer.color;
                _cloneRenderer.color = new Color32(c.r, c.g, c.b, 255);
                if (isAD)
                {
                    adAtt.enabled = true;
                }
                else if (!isAD)
                {
                    attCollsion.enabled = true;
                    attCollider.enabled = true;
                }

                collider.isTrigger = false;
                RailInput.onRail = false;
                Clone.transform.position = new Vector3(RailInput.raillTrans.x, RailInput.raillTrans.y, 0);

                //아군 카운트 올리기
                OnUnitNumChange.Invoke(unitCode);

                StartCoroutine(CoolTime());
            }

            else if (!RailInput.onRail)
            {
                Clone.SetActive(false);
                AudioManager.Instance.PlaySfx(AudioManager.Sfx.Warning);
            }
        }
    }

    IEnumerator CoolTime()
    {
        isCoolTime = true;
        coolTime = maxCoolTime;
        yield return new WaitForSeconds(maxCoolTime);
        isCoolTime = false;
    }
}
