using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInputManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public GameObject target;
    

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
        Debug.Log("���� Ŭ������");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector3(eventData.position.x, eventData.position.y, 0);
        //Debug.Log(eventData);

    }

    public void OnDrop(PointerEventData eventData)
    {
        
        //if (eventData == target)
        //{
        //    Debug.Log("����ī�� �ߵ�");
        //}

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("qudtls");
    }
}
