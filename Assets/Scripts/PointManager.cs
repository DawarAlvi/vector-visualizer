using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    [SerializeField] Slider sliderX;
    [SerializeField] Slider sliderY;
    [SerializeField] Slider sliderZ;

    void Update()
    {
        transform.position = new Vector3(sliderX.value, sliderY.value, sliderZ.value);
    }
}
