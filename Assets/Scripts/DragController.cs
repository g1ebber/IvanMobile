using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public Draggable LastDragged => _lastDragged;
    private bool _isDragActive;
    private Vector2 _screenPosition;
    private Vector3 _worldPosition;
    private Draggable _lastDragged;

    private void Awake()
    {
        DragController[] controllers = FindObjectsOfType<DragController>();
        if (controllers.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (_isDragActive && Input.GetMouseButtonUp(0))
        {
            Drop();
            return;
        }

        if (Input.GetMouseButton(0))
        {
            // Debug.Log("0");
            Vector3 mousePos = Input.mousePosition;
            _screenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else
        {
            return;
        }

        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

        if (_isDragActive)
        {
            // Debug.Log("1");
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if (hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if (draggable != null)
                {
                    _lastDragged = draggable;
                    InitDrag();
                }
            }
        }
    }

    void InitDrag()
    {
        _lastDragged.lastPosition = _lastDragged.transform.position;
        // Debug.Log("2");
        UpdateDragStatus(true);
    }

    void Drag()
    {
        // Debug.Log("3");
        _lastDragged.transform.position = new Vector2(_worldPosition.x, _worldPosition.y);
    }

    void Drop()
    {
        // Debug.Log("4");
        UpdateDragStatus(false);
    }

    void UpdateDragStatus(bool isDragging)
    {
        _isDragActive = _lastDragged.isDragging = isDragging;
        _lastDragged.gameObject.layer = isDragging ? Layer.Dragging : Layer.Default;
    }
}
