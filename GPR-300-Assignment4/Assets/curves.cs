using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curves : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform point0, point1, point2, point3;

    private int numPoints = 50;
    private Vector3[] positions = new Vector3[50];
    
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.positionCount = numPoints;
        DrawCubicCurve();
    }

    // Update is called once per frame
    void Update()
    {
        DrawCubicCurve();
    }

    private void DrawCubicCurve()
    {
        for (int i = 1; i < numPoints + 1; i++)
        {
            float t = i / (float)numPoints;
            positions[i - 1] = cubicBezierCurve(t, point0.position, point1.position, point2.position, point3.position);
        }

        lineRenderer.SetPositions(positions);
    }

    private Vector3 cubicBezierCurve(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float uu = u * u;
        float uuu = uu * u;
        
        float tt = t * t;
        float ttt = tt * t;
        
        
        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * p3;

        return p;
    }
}
