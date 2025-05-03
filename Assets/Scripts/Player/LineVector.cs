using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineDrawer : MonoBehaviour
{
    private LineRenderer lineRenderer;

    public void Initialize()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
    }

    public void DrawVectorLine(Vector3 pointA, Vector3 pointB)
    {
        lineRenderer.enabled = true;

        lineRenderer.SetPosition(0, pointA);
        lineRenderer.SetPosition(1, pointB);
    }

    public void CleenLine()
    {
        lineRenderer.enabled = false;
    }
}
