using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInputManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public GameObject Unit;
    public GameObject Clone;



    private BoxCollider2D collider;


    [SerializeField]
    private EnemyMove EnemyMovemate2; // ������ ������ ��ũ��Ʈ

    private SpriteRenderer _cloneRenderer; //������ �������� ���� ��������Ʈ ������


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
        
        Clone = Instantiate(Unit);
        _cloneRenderer = Clone.GetComponent<SpriteRenderer>();
        EnemyMovemate2 = Clone.GetComponent<EnemyMove>();
        collider = Clone.GetComponent<BoxCollider2D>();

        Color32 c = _cloneRenderer.color;
        _cloneRenderer.color = new Color32(c.r, c.g, c.b, 30);

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

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log(eventData);
        //if (eventdata == target)
        //{
        //    debug.log("����ī�� �ߵ�");
        //}

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

        }

        else if (!RailInput.onRail)
        {
            Destroy(Clone);
            
        }
    }




}
