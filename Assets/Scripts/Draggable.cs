using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool isDragging;
    public Vector3 lastPosition;

    private Collider2D _collider;
    private DragController _dragController;
    private float _movementTime = 15f;
    private System.Nullable<Vector3> _movementDestination;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _dragController = FindObjectOfType<DragController>();
    }

    private void FixedUpdate()
    {
        if (_movementDestination.HasValue)
        {
            if (isDragging)
            {
                _movementDestination = null;
                return;
            }

            if (transform.position == _movementDestination)
            {
                gameObject.layer = Layer.Default;
                _movementDestination = null;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, _movementDestination.Value, _movementTime * Time.fixedDeltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Draggable colliderDraggable = other.GetComponent<Draggable>();

        if (colliderDraggable != null && _dragController.LastDragged.gameObject == gameObject)
        {
            ColliderDistance2D colliderDistance2D = other.Distance(_collider);
            Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
            transform.position -= diff;
        }

        if (other.CompareTag("DropValid"))
        {
            _movementDestination = other.transform.position;
        }
        else if (other.CompareTag("DropInvalid"))
        {
            _movementDestination = lastPosition;
        }
    }
}
