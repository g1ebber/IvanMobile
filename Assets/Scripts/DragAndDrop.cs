using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    // public Draggable LastDragged => _lastDragged;
    
    public delegate void DragEndedDelegate(DragAndDrop draggableObject); // for be able to snap this object
    public DragEndedDelegate dragEndedCallback;

    private Vector3 _dragOffset; // distance between center of an object and mouse pointer
    private Camera _cam; // for calculating mouse position

    private bool isDragActive; // drag status
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
        if (isDragActive)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
        }
    }

    void OnMouseDown()
    {
        // Debug.Log("0");
        if (isDragActive == true)
        {
            isDragActive = false;
            // dragEndedCallback(this);
            // Debug.Log("1");
        } 
        else
        {
            isDragActive = true;
        }


        _dragOffset = transform.position - GetMousePos();
    }

    private void OnMouseUp()
    {
        if (timer > 0.1f)
        {
            isDragActive = false;
            timer = 0f;
            dragEndedCallback(this);
            Debug.Log("2");
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
