using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    [SerializeField] GameObject GameObjectToToggle;
    public void OnToggleButtonPressed(bool value)
    {
        GameObjectToToggle.SetActive(value);
    }
}
