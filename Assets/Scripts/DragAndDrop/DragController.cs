using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
DragController is applied to the object. 
This object will control the dragging of all objects with this capability (that has Draggable component).

Functional:
    - Dragging object by holding mouse button.
    - Snapping inside another item if the drop is valid.
    - Going to the starting position if the drop is not valid.
    - Avoiding overlapping items by repositioning in the closest valid position.
    - Does not allow to drag an object beyond the specified boundaries (which are set in Draggable object fields).
 */

public class DragController : MonoBehaviour
{
    public Draggable LastDragged => _lastDragged; // to be used in Draggable
    private Draggable _lastDragged; // to store the last dragged object

    private Camera _cam; // for calculating mouse position

    private Vector3 _worldPosition; // to store mouse position
    private Vector3 _dragOffset; // distance between center of an object and mouse

    private bool _isDragActive;

    private void Awake()
    {
        _cam = Camera.main;
        DragController[] controllers = FindObjectsOfType<DragController>();
        if (controllers.Length > 1) // must be only 1 DragController
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (_isDragActive && Input.GetMouseButtonUp(0)) // to drop
        {
            Drop();
            return;
        }

        if (Input.GetMouseButton(0)) // if mouse button pressed - always check mouse position
        {
            _worldPosition = GetMousePos();
        }
        else
        {
            return;
        }

        if (_isDragActive) // to drag
        {
            Drag();
        }
        else // if we don't drag anythink
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if (hit.collider != null) // if we clicked on game object
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if (draggable != null) // if game object can be dragged
                {
                    _lastDragged = draggable;
                    _dragOffset = _lastDragged.transform.position - _worldPosition;
                    InitDrag();
                }
            }
        }
    }

    void InitDrag() // start dragging
    {
        _lastDragged.lastPosition = _lastDragged.transform.position;
        UpdateDragStatus(true);
    }

    void Drag()
    {
        //Debug.Log("Drag");

        if (_worldPosition.y > _lastDragged.deadZoneTopY) // check if we cross top bounboundary
        {
            if (_worldPosition.x > _lastDragged.deadZoneRightX)
            {
                _lastDragged.transform.position = new Vector2(_lastDragged.deadZoneRightX, _lastDragged.deadZoneTopY);
            } else if (_worldPosition.x < _lastDragged.deadZoneLeftX)
            {
                _lastDragged.transform.position = new Vector2(_lastDragged.deadZoneLeftX, _lastDragged.deadZoneTopY);
            }
            else
            {
                _lastDragged.transform.position = new Vector2(_worldPosition.x + _dragOffset.x, _lastDragged.deadZoneTopY);
            }
        } else if (_worldPosition.y < _lastDragged.deadZoneBotY) // check if we cross bottom bounboundary
        {
            if (_worldPosition.x > _lastDragged.deadZoneRightX)
            {
                _lastDragged.transform.position = new Vector2(_lastDragged.deadZoneRightX, _lastDragged.deadZoneBotY);
            }
            else if (_worldPosition.x < _lastDragged.deadZoneLeftX)
            {
                _lastDragged.transform.position = new Vector2(_lastDragged.deadZoneLeftX, _lastDragged.deadZoneBotY);
            }
            else
            {
                _lastDragged.transform.position = new Vector2(_worldPosition.x + _dragOffset.x, _lastDragged.deadZoneBotY);
            }
        }
        else if (_worldPosition.x > _lastDragged.deadZoneRightX) // check if we cross right bounboundary
        {
            if (_worldPosition.y > _lastDragged.deadZoneTopY)
            {
                _lastDragged.transform.position = new Vector2(_lastDragged.deadZoneRightX, _lastDragged.deadZoneTopY);
            }
            else if (_worldPosition.y < _lastDragged.deadZoneBotY)
            {
                _lastDragged.transform.position = new Vector2(_lastDragged.deadZoneRightX, _lastDragged.deadZoneBotY);
            }
            else
            {
                _lastDragged.transform.position = new Vector2(_lastDragged.deadZoneRightX, _worldPosition.y + _dragOffset.y);
            }
        }
        else if (_worldPosition.x < _lastDragged.deadZoneLeftX) // check if we cross left bounboundary
        {
            if (_worldPosition.y > _lastDragged.deadZoneTopY)
            {
                _lastDragged.transform.position = new Vector2(_lastDragged.deadZoneLeftX, _lastDragged.deadZoneTopY);
            }
            else if (_worldPosition.y < _lastDragged.deadZoneBotY)
            {
                _lastDragged.transform.position = new Vector2(_lastDragged.deadZoneLeftX, _lastDragged.deadZoneBotY);
            }
            else
            {
                _lastDragged.transform.position = new Vector2(_lastDragged.deadZoneLeftX, _worldPosition.y + _dragOffset.y);
            }
        }
        else // dragging free
        {
            _lastDragged.transform.position = new Vector2(_worldPosition.x + _dragOffset.x, _worldPosition.y + _dragOffset.y);
        }

    }

    void Drop()
    {
        UpdateDragStatus(false);
    }

    void UpdateDragStatus(bool isDragging)
    {
        _isDragActive = _lastDragged.isDragging = isDragging;
        // we use layers in Draggable to don't allow dragging draggable objects on each others
        _lastDragged.gameObject.layer = isDragging ? Layer.Dragging : Layer.Default;
    }

    Vector3 GetMousePos()
    {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
