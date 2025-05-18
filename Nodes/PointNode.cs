using UnityEngine;
using XNode;

public class PointNode : Node
{
    // Declare inputs for x, y, z coordinates
    [Input, Tooltip("X-coordinate (float)")]
    public float x;

    [Input, Tooltip("Y-coordinate (float)")]
    public float y;

    [Input, Tooltip("Z-coordinate (float)")]
    public float z;

    [SerializeField, Tooltip("Enable this point node")]
    public bool enable = true;

    [SerializeField, Tooltip("Toggle point live preview in Unity 3D")]
    public bool livePreview = false;

    // Output port that returns the constructed Vector3 point
    [Output(ShowBackingValue.Never)] public Vector3 point;

    public override object GetValue(NodePort port)
    {
        if (port.fieldName == "point")
        {
            // If any of the x/y/z inputs is connected, 
            // use that connected value; otherwise use the local field’s default.
            float X = GetInputValue("x", x);
            float Y = GetInputValue("y", y);
            float Z = GetInputValue("z", z);

            return new Vector3(X, Y, Z);
        }
        return null;
    }
}
