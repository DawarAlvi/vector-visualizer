using UnityEngine;
using UnityEngine.UI;

public class SliderValueText : MonoBehaviour
{
    Text text;
    private void Awake()
    {
        text = GetComponent<Text>();
    }
    public void OnSliderValueChanged(float value)
    {
        value = Mathf.Round(value * 10) / 10;
        text.text = value.ToString();
    }
}
