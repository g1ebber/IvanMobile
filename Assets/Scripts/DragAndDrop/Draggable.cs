using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
DragController is applied to the object. This object will be draggable.
This code must be used with DragController (object that has DragController component).

Interaction Requirements:
    - Snap object must have tag - "DropValid" and Collider.
    - Object on which nothing can be placed must have tag - "DropInvalid" and Collider.


All draggable objects must have:
    - This component.
    - Collider + "Is Trigger".
    - RigitBody + "Body Type" - Kinematic.
 */

public class Draggable : MonoBehaviour
{
    private DragController _dragController; // to use DragController

    private Collider2D _collider; // dragged object collider

    private System.Nullable<Vector3> _movementDestination; // the point at which we drop an object
    public Vector3 lastPosition; // the point at which we picked up an object

    private float _movementTime = 15f; // speed of snapping
    public bool isDragging;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _dragController = FindObjectOfType<DragController>();
    }

    private void FixedUpdate()
    {
        if (_movementDestination.HasValue)
        {
            if (isDragging) // unsnap via DragController
            {
                _movementDestination = null;
                return;
            }

            if (transform.position == _movementDestination) // if we drop an object
            {
                gameObject.layer = Layer.Default;
                _movementDestination = null;
            }
            else // if we need help with snapping
            {
                transform.position = Vector3.Lerp(transform.position, _movementDestination.Value, _movementTime * Time.fixedDeltaTime);
            }
        }
    }

    // to check with which object we collide when drop an object
    private void OnTriggerEnter2D(Collider2D other)
    {
        Draggable colliderDraggable = other.GetComponent<Draggable>();

        // if we collide with other draggable object
        if (colliderDraggable != null && _dragController.LastDragged.gameObject == gameObject)
        {
            ColliderDistance2D colliderDistance2D = other.Distance(_collider);
            Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
            transform.position -= diff;
        }

        // if we can put an object here - we snap it
        if (other.CompareTag("DropValid"))
        {
            _movementDestination = other.transform.position;
        } // if we can't - an object return at start position
        else if (other.CompareTag("DropInvalid"))
        {
            _movementDestination = lastPosition;
        }
    }
}
