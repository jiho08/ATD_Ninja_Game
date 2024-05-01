using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInputManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler //,IDropHandler
{
    public int UnitCode; //��¥ ����
    private GameObject Clone; //�ӽ÷� ���� ������



    private BoxCollider2D collider; // ������ �ݶ��̴� 


    private PlayerUnit UnitMovemate2; // ������ ������ ��ũ��Ʈ
    [SerializeField]
    private SpawnManager spawnM; // ���� ��ȯ ��ũ��Ʈ
    private AttackCollsion attCollsion;//���� ���� ���� �ݶ��̴� ��ũ��Ʈ
    private BoxCollider2D attCollider;//���� ���� ���� �ݶ��̴�
    private PlayerADUnit adAtt; //���Ÿ� ���� ���� ��ũ��Ʈ    

    private bool isAD; //���� ���������ΰ� �ƴѰ�

    private SpriteRenderer _cloneRenderer; //������ �������� ���� ��������Ʈ ������


    private Vector3 targetPosition; // ������ ���콺 ������ ���󰡰� �ϱ����� ��������



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


        _cloneRenderer = Clone.GetComponentInChildren<SpriteRenderer>();
        UnitMovemate2 = Clone.GetComponent<PlayerUnit>();
        collider = Clone.GetComponent<BoxCollider2D>();

        if (Clone == null) return;
        if (Clone.gameObject.GetComponent<PlayerADUnit>() != null)
        {
            isAD = true;
            adAtt = Clone.GetComponent<PlayerADUnit>();
            adAtt.enabled = false;
        }
        else if(Clone.gameObject.GetComponent<PlayerADUnit>() == null)
        {
            isAD = false;
            attCollsion =  Clone.transform.GetChild(0).GetChild(0).GetComponent<AttackCollsion>();
            attCollider =  Clone.transform.GetChild(0).GetChild(0).GetComponent<BoxCollider2D>();
            attCollsion.enabled = false;
            attCollider.enabled = false;
        }

        Color32 c = _cloneRenderer.color;
        _cloneRenderer.color = new Color32(c.r, c.g, c.b, 100);

        UnitMovemate2.enabled = false;

        collider.enabled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Clone == null) return;

        targetPosition = Camera.main.ScreenToWorldPoint(eventData.position);

        Clone.transform.position = new Vector3(targetPosition.x, targetPosition.y, 0);
        //transform.position = new Vector3(eventData.position.x, eventData.position.y, 0);
        //Debug.Log(eventData);


    }


    public void OnEndDrag(PointerEventData eventData)
    {
        if (Clone == null) return;

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
            else if(!isAD)
            {
                attCollsion.enabled = true;
                attCollider.enabled = true;
            }

            collider.isTrigger = false;
            RailInput.onRail = false;
            Clone.transform.position = new Vector3(RailInput.raillTrans.x, RailInput.raillTrans.y, 0);
        }

        else if (!RailInput.onRail)
        {
            Clone.SetActive(false);

        }
    }




}
