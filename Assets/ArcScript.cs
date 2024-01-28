using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ArcScript : MonoBehaviour
{
    LineRenderer aimArc;


    public float velocity;
    public float angle;
    public int resolution = 10;
    public float gravForce;

    float radianAngle;

    void Awake()
    {
        aimArc = GetComponent<LineRenderer>();
        //gravForce = Mathf.Abs(Physics3D.gravity);
    }

    void Start()
    {
        RenderArc();
    }

    private void Update()
    {
        
    }

    void RenderArc()
    {
        Vector3 startPosition;
        aimArc.SetVertexCount(resolution + 1);
        aimArc.SetPositions(CalcArcArray());
    }

    Vector3[] CalcArcArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];
        radianAngle = Mathf.Deg2Rad * angle;
        float maxDist = (velocity * velocity * Mathf.Sin(2*radianAngle) / Mathf.Abs(gravForce));
        
        for (int i = 0; i <= resolution; i++) 
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CalcArcPoint( t, maxDist );
        }

        return arcArray;
    }

    Vector3 CalcArcPoint( float t, float maxDist )
    {
        float y, x;
        x = t * maxDist;
        y = x * Mathf.Tan(radianAngle) - ( (gravForce * x * x) / 2 * Mathf.Pow( (velocity * Mathf.Cos(radianAngle) ), 2) );

        return new Vector3(x, y);
    }
}
