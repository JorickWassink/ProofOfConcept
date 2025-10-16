using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RangeCircle : MonoBehaviour
{
    public float radius = 3f;
    public int segments = 100;
    private LineRenderer lineRenderer;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false;
        lineRenderer.loop = true;
        lineRenderer.positionCount = segments;
        lineRenderer.widthMultiplier = 0.05f;
        lineRenderer.enabled = false;
    }

    public void DrawCircle(float r)
    {
        radius = r;
        float angle = 0f;

        for (int i = 0; i < segments; i++)
        {
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
            angle += 2 * Mathf.PI / segments;
        }
    }

    public void Show(bool toggle)
    {
        lineRenderer.enabled = toggle;
    }

    public void SetColor(Color color)
    {
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
    }
}