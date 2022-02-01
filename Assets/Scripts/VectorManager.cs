using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorManager : MonoBehaviour
{
    [SerializeField] Transform point;
    [SerializeField] Transform arrowCylinder;
    [SerializeField] Transform arrowCone;

    void Update()
    {
        float distance = Vector3.Distance(Vector3.zero, point.position);

        transform.LookAt(point);
        arrowCone.localPosition = new Vector3(0,0, distance);
        arrowCylinder.localScale = new Vector3(1, distance, 1);


    }
}
