using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatedPointManager : MonoBehaviour
{
    [SerializeField]Transform point_1;
    [SerializeField]Transform point_2;

    Transform _transform;
    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.position = Vector3.Cross(point_1.position, point_2.position);
    }
}
