using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    [SerializeField] Slider sliderX;
    [SerializeField] Slider sliderY;
    [SerializeField] Slider sliderZ;

    Transform _transform;
    bool _normalizing = false;
    private void Awake()
    {
        _transform = transform;
    }
    void Update()
    {
        if(!_normalizing)
        {
            _transform.position = new Vector3(sliderX.value, sliderY.value, sliderZ.value);
        }
    }
    IEnumerator NormalizePointPosition()
    {
        _normalizing = true;

        Vector3 initialPosition = _transform.position;
        Vector3 finalPosition = _transform.position.normalized;

        float duration = 1;
        float elapsed = 0;

        while (elapsed < duration)
        {
            _transform.position = Vector3.Lerp(initialPosition, finalPosition, elapsed/duration);

            sliderX.value = _transform.position.x;
            sliderY.value = _transform.position.y;
            sliderZ.value = _transform.position.z;

            elapsed += Time.deltaTime;
            yield return null;
        }
       _normalizing = false;
    }
}
