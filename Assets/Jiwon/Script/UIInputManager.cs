using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInputManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public GameObject target;
    public GameObject Clone;

    private BoxCollider2D collider;


    [SerializeField]
    private EnemyMovemate EnemyMovemate2; // 유닛의 움직임 스크립트

    private SpriteRenderer _cloneRenderer; //유닛의 색변경을 위한 스프라이트 렌더러
    

    private Vector3 targetPosition;


    [SerializeField] private Vector3 posi1;
    private void Awake()
    {
        //camera = Camera.main;
        
        
    }
    private void Start()
    {

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("지금 클릭당함");
        Clone = Instantiate(target);
        _cloneRenderer = Clone.GetComponent<SpriteRenderer>();
        EnemyMovemate2 = Clone.GetComponent<EnemyMovemate>();
        collider = Clone.GetComponent<BoxCollider2D>();

        Color32 c = _cloneRenderer.color;
        _cloneRenderer.color = new Color32(c.r, c.g, c.b, 30);

        EnemyMovemate2.enabled = false;

        collider.isTrigger = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        targetPosition = Camera.main.ScreenToWorldPoint(eventData.position);

        Clone.transform.position = new Vector3(targetPosition.x,targetPosition.y,0);
        //transform.position = new Vector3(eventData.position.x, eventData.position.y, 0);
        //Debug.Log(eventData);


    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log(eventData);
        //if (eventdata == target)
        //{
        //    debug.log("함정카드 발동");
        //}

    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (RailInput.instance.GetOnRail())
        {
            EnemyMovemate2.enabled = true;
            Color32 c = _cloneRenderer.color;
            _cloneRenderer.color = new Color32(c.r, c.g, c.b, 255);
            Debug.Log("qudtls");
            collider.isTrigger = false;

        }

        else if(!RailInput.instance.GetOnRail())
        {
            Destroy(Clone);
            Debug.Log("whwehlTek");
        }
    }



    
}
