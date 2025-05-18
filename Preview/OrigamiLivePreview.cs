using UnityEngine;
using XNode;

public class OrigamiLivePreview : MonoBehaviour
{
    // Drag the node graph asset into the inspector.
    public MyNodeGraph nodeGraph;

    private void OnDrawGizmos()
    {
        if (nodeGraph == null) return;

        // Iterate over every node in the graph
        foreach (Node node in nodeGraph.nodes)
        {
            // Check for PointNode instances
            if (node is PointNode pointNode && pointNode.enable && pointNode.livePreview)
            {
                // Use GetPort("point") instead of a string literal
                Vector3 point = (Vector3)pointNode.GetValue(pointNode.GetPort("point"));
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(point, 0.1f);
            }

            // Check for LineNode instances
            if (node is LineNode lineNode && lineNode.enable && lineNode.livePreview)
            {
                // These methods accept a string and a fallback, so no change is needed here.
                Vector3 start = lineNode.GetInputValue("startPoint", Vector3.zero);
                Vector3 end = lineNode.GetInputValue("endPoint", Vector3.zero);
                Gizmos.color = Color.red;
                Gizmos.DrawLine(start, end);
            }
        }
    }
}
