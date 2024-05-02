using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailInput : MonoBehaviour
{
    public static bool onRail;

    private BoxCollider2D collider;
    private Bounds bounds;
    public static Vector2 raillTrans;


    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        bounds = collider.bounds;
        raillTrans = new Vector2(bounds.min.x, bounds.center.y);
    }
    
    private void OnMouseEnter()
    {
        onRail = true;
        raillTrans = new Vector2(bounds.min.x, bounds.center.y);
    }
    private void OnMouseExit()
    {
        onRail = false;
    }



    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Unit"))
    //    {
    //        onRail = false;

    //    }
    //}

    //public GameObject my;
    //public static RailInput instance = null;


    //public bool onRail;

    //private void Awake()
    //{
    //    my = gameObject;
    //    if(instance == null)
    //    {
    //        instance = this;
    //    }
    //}
    //private void Start()
    //{
    //    onRail = false;
    //}


    //private void OnMouseEnter()
    //{
    //    onRail = true;
    //}

    //private void OnMouseExit()
    //{
    //    onRail = false;
    //}

    //public bool GetOnRail()
    //{
    //    return (onRail);
    //}


}
