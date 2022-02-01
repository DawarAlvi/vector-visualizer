using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    bool isPanelOpen = true;
    [SerializeField] Animation clip;

    [SerializeField] Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void OnToggleButtonPressed()
    {
        if(isPanelOpen)
        {
            isPanelOpen = false;
            animator.Play("closePanel");
        }
        else
        {
            isPanelOpen = true;
            animator.Play("openPanel");
        }

    }
}
