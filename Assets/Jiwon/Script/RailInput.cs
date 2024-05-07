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



    
}
