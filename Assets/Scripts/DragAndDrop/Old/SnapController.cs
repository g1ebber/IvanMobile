using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This is an old implementation of snaping system.
SnapController is applied to the object.
This object will control the which objects can be dragged on which snap points exist.
This implementation checks if the object is in a certain zone relative to the point + the animation is not smooth.
 */

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPoints;
    public List<DragAndDrop> draggableObjects;
    [SerializeField] private float snapRange = 1f;

    void Start()
    {
        foreach(DragAndDrop draggableObject in draggableObjects)
        {
            draggableObject.dragEndedCallback = OnDragEnded;
        }
    }

    private void OnDragEnded(DragAndDrop draggableObject)
    {
        float clossestDistance = -1;
        Transform clossestSnapPoint = null;

        foreach(Transform snapPoint in snapPoints)
        {
            float currentDistance = Vector2.Distance(draggableObject.transform.localPosition, snapPoint.localPosition);
            if (clossestSnapPoint == null || currentDistance < clossestDistance)
            {
                clossestSnapPoint = snapPoint;
                clossestDistance = currentDistance;
            }
        }

        if (clossestSnapPoint != null && clossestDistance <= snapRange)
        {
            draggableObject.transform.localPosition = clossestSnapPoint.localPosition;
        }
    }
}
