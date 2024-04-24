using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInputManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler //,IDropHandler
{
    public int UnitCode; //진짜 유닛
    private GameObject Clone; //임시로 유닛 담을거



    private BoxCollider2D collider; // 유닛의 콜라이더 


    [SerializeField]
    private EnemyMove EnemyMovemate2; // 유닛의 움직임 스크립트
    [SerializeField]
    private SpawnManager spawnM; // 유닛 소환 스크립트

    private SpriteRenderer _cloneRenderer; //유닛의 색변경을 위한 스프라이트 렌더러


    private Vector3 targetPosition; // 유닛의 마우스 포인터 따라가게 하기위한 뷰포인터


    //[SerializeField] 
    //private Vector3 posi1;
    private void Awake()
    {
        //camera = Camera.main;


    }
    private void Start()
    {

    }
    public void OnBeginDrag(PointerEventData eventData)
    {

        Clone = spawnM.UnitSpawn(UnitCode);
        _cloneRenderer = Clone.GetComponent<SpriteRenderer>();
        EnemyMovemate2 = Clone.GetComponent<EnemyMove>();
        collider = Clone.GetComponent<BoxCollider2D>();

        Color32 c = _cloneRenderer.color;
        _cloneRenderer.color = new Color32(c.r, c.g, c.b, 100);

        EnemyMovemate2.enabled = false;

        collider.isTrigger = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        targetPosition = Camera.main.ScreenToWorldPoint(eventData.position);

        Clone.transform.position = new Vector3(targetPosition.x, targetPosition.y, 0);
        //transform.position = new Vector3(eventData.position.x, eventData.position.y, 0);
        //Debug.Log(eventData);


    }


    public void OnEndDrag(PointerEventData eventData)
    {

        if (RailInput.onRail)
        {
            EnemyMovemate2.enabled = true;
            Color32 c = _cloneRenderer.color;
            _cloneRenderer.color = new Color32(c.r, c.g, c.b, 255);

            collider.isTrigger = false;
            RailInput.onRail = false;
            Clone.transform.position = new Vector3(RailInput.raillTrans.x,RailInput.raillTrans.y,0);
        }

        else if (!RailInput.onRail)
        {
            Clone.SetActive(false);
            
        }
    }

    


}
