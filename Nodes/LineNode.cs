using UnityEngine;
using XNode;

public class LineNode : Node
{
    [Input, Tooltip("Start point of the line")]
    public Vector3 startPoint;

    [Input, Tooltip("End point of the line")]
    public Vector3 endPoint;

    [SerializeField, Tooltip("Enable this line node")]
    public bool enable = true;

    [SerializeField, Tooltip("Toggle line live preview in Unity 3D")]
    public bool livePreview = false;

    // Output port that returns a Line struct
    [Output(ShowBackingValue.Never)] public Line line;

    public override object GetValue(NodePort port)
    {
        if (port.fieldName == "line")
        {
            // Uses GetInputValue to allow connections to override the node’s values
            Vector3 start = GetInputValue("startPoint", startPoint);
            Vector3 end = GetInputValue("endPoint", endPoint);
            return new Line(start, end);
        }
        return null;
    }
}
