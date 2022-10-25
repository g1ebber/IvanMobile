using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 This is an old implementation of drag and drop functionality.
 DragAndDrop is applied to the object. This object can be moved by clicking or holding the mouse button.
 */

public class DragAndDrop : MonoBehaviour
{    
    public delegate void DragEndedDelegate(DragAndDrop draggableObject); // for be able to snap this object
    public DragEndedDelegate dragEndedCallback;

    private Vector3 _dragOffset; // distance between center of an object and mouse pointer
    private Camera _cam; // for calculating mouse position

    private bool _isDragActive; // drag status
    private float _timer; // for checking type of controls: click or drag
    [SerializeField] private float _speed = 1000; // speed of an object following the cursor

    void Awake()
    {
        _timer = 0f;
        _cam = Camera.main;
    }

    private void Update()
    {
        if (_isDragActive)
        {
            _timer += Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
        }
    }

    void OnMouseDown()
    {
        if (_isDragActive == true)
        {
            _isDragActive = false;
        } 
        else
        {
            _isDragActive = true;
        }


        _dragOffset = transform.position - GetMousePos();
    }

    private void OnMouseUp()
    {
        if (_timer > 0.1f)
        {
            _isDragActive = false;
            _timer = 0f;
            dragEndedCallback(this);
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
}
