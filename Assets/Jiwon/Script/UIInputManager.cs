using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInputManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{
    public GameObject target;
    public GameObject Clone;

    public RailInput RailInput;

    

    private Vector3 targetPosition;


    [SerializeField] private Vector3 posi1;
    private void Awake()
    {
        //camera = Camera.main;
        RailInput = GetComponent<RailInput>();
    }
    private void Start()
    {

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("지금 클릭당함");
        Clone = Instantiate(target);
        
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
        //if (eventData == target)
        //{
        //    Debug.Log("함정카드 발동");
        //}

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(Clone);
        Debug.Log("qudtls");
    }

    
}
