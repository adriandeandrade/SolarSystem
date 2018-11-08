using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class EllipseRenderer : MonoBehaviour
{
    private LineRenderer lr;

    [Range(3, 36)]
    public int segements;
    public Ellipse ellipse;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        CalculateEllipse();
    }


    void CalculateEllipse()
    {
        Vector3[] points = new Vector3[segements + 1];
        for (int i = 0; i < segements; i++)
        {
            Vector2 position2D = ellipse.Evaluate((float)i / (float)segements);
            points[i] = new Vector3(position2D.x, position2D.y, 0f);
        }

        points[segements] = points[0];
        lr.positionCount = segements + 1;
        lr.SetPositions(points);
    }

    private void OnValidate()
    {
        if (Application.isPlaying && lr != null)
        {
            CalculateEllipse();
        }
    }
}
