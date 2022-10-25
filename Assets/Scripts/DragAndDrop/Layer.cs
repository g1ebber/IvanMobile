using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script just store layers IDs.
We use layers in Draggable to don't allow dragging draggable objects on each others.

The project must:
    - Include this layers.
    - Have Physics 2D Layers Collision (Matrix) disabled for "Dragging" layer to all other layers. 
 */
public class Layer : MonoBehaviour
{
    public static readonly int Default = 0;
    public static readonly int Dragging = 8;
}
