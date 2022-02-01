using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform camX;
    [SerializeField] Transform camY;

    Quaternion initialCamXRotation;
    Quaternion initialCamYRotation;

    bool isResetting = false;

    private void Start()
    {
        initialCamXRotation = camX.rotation;
        initialCamYRotation = camY.rotation;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        if(!isResetting
           && Input.GetMouseButton(0) 
           && !IsPointerOverUIElement()
           )
        {
            camX.Rotate(-Vector3.right, mouseY);
            camY.Rotate( Vector3.up   , mouseX);
        }
    }

    public void OnResetCameraPressed()
    {
        if(!isResetting)
        {
            StopAllCoroutines();
            StartCoroutine(ResetCamera());
        }
    }
    IEnumerator ResetCamera()
    {
        isResetting = true;

        Quaternion fromRotationX = camX.rotation;
        Quaternion fromRotationY = camY.rotation;

        float duration = 1f;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            t = t * t * t * (t * (6f * t - 15f) + 10f);

            camX.rotation = Quaternion.Lerp(fromRotationX, initialCamXRotation, t);
            camY.rotation = Quaternion.Lerp(fromRotationY, initialCamYRotation, t);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        isResetting = false;
    }


    public static bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }
    public static bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaycastResults)
    {
        for (int index = 0; index < eventSystemRaycastResults.Count; index++)
        {
            RaycastResult curRaycastResult = eventSystemRaycastResults[index];
            if (curRaycastResult.gameObject.layer == LayerMask.NameToLayer("UI"))
                return true;
        }
        return false;
    }
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        return raycastResults;
    }

}