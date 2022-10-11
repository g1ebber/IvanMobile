using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropBox : MonoBehaviour
{
    private Vector3 _dragOffset; // for center fulcrum of an object
    private Camera _cam; // main camera object
   
    private bool isCarry; // object status
    //private bool isInRoom;
    
    private float timer; // for checking type of controls: click or drag
    [SerializeField] private float _speed = 1000; // speed of an object following the cursor

    void Awake()
    {
        timer = 0f;
        _cam = Camera.main;
    }

    private void Update()
    {
        if (isCarry)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
        }
    }

    void OnMouseDown()
    {
        Debug.Log("0");
        if (Input.GetMouseButtonDown(0) && (isCarry == true))
        {
            isCarry = false;
        } 
        else
        {
            isCarry = true;
        }


        _dragOffset = transform.position - GetMousePos();
    }

    private void OnMouseUp()
    {
        if (timer > 0.1f)
        {
            isCarry = false;
            timer = 0f;
        }
    }

    void OnMouseDrag()
    {
        transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
    }

    Vector3 GetMousePos()
    {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Room")
    //    {
    //        isInRoom = true;
    //    }
    //    else
    //    {
    //        isInRoom = false;
    //    }
    //}
}
