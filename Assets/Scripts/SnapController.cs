using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapController : MonoBehaviour
{
    public List<Transform> snapPoints; // target snaps
    public List<DragAndDrop> draggableObjects; // objects to snap
    [SerializeField] private float snapRange = 1f; // snap area for snap point
                                       // нужно заменить на другой тип привязки

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
