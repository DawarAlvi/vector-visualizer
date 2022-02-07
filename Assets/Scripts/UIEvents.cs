using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvents : MonoBehaviour
{
    [SerializeField] GameObject _vector_1;
    [SerializeField] GameObject _vector_2;
    [SerializeField] GameObject _calculatedVector;
    [SerializeField] GameObject _point_1;
    [SerializeField] GameObject _point_2;
    [SerializeField] GameObject _calculatedPoint;

    MeshRenderer _point_1_Renderer;
    MeshRenderer _point_2_Renderer;
    MeshRenderer _calculatedPointRenderer;
    PointManager _point_1_Manager;
    PointManager _point_2_Manager;

    private void Awake()
    {
        _point_1_Renderer = _point_1.GetComponent<MeshRenderer>();
        _point_2_Renderer = _point_2.GetComponent<MeshRenderer>();
        _calculatedPointRenderer = _calculatedPoint.GetComponent<MeshRenderer>();
        _point_1_Manager = _point_1.GetComponent<PointManager>();
        _point_2_Manager = _point_2.GetComponent<PointManager>();
    }
    public void OnVectorPointToggle(bool value)
    {
        _vector_1.SetActive(!value);
        _vector_2.SetActive(!value);
        _calculatedVector.SetActive(!value);
        _point_1_Renderer.enabled = value;
        _point_2_Renderer.enabled = value;
        _calculatedPointRenderer.enabled = value;
    }

    public void OnNormalizeVector()
    {
        _point_1_Manager.StartCoroutine("NormalizePointPosition");
        _point_2_Manager.StartCoroutine("NormalizePointPosition");
    }
}
