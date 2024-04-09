using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public curves[] curves;

    private int i = 0;
    private float u = 0.0f;

    private Vector3 GetCurve(curves c)
    {
        var p0 = c.point0.position;
        var p1 = c.point1.position;
        var p2 = c.point2.position;
        var p3 = c.point3.position;

        return c.cubicBezierCurve(u - i, p0, p1, p2, p3);
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime * 0.25f;
        i = (int)Math.Floor(u);

        //Debug.Log("I: " + i);
        //Debug.Log("U: " + u);

        if (u > curves.Length)
        {
            u = 0.0f;
            i = 0;
        }
        

        var current_curve = curves[i];
        transform.position = GetCurve(current_curve);
        
        // always last?
        u += dt;
    }

}
