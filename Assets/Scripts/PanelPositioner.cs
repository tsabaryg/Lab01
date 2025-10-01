using UnityEngine;

public class PanelPositioner : MonoBehaviour
{
    public Transform cameraTransform; // גרור CenterEyeAnchor מתוך OVRCameraRig

    void Start()
    {
        if (cameraTransform != null)
        {
            // ממקם את הפאנל 1.5 מטר מול המצלמה עם התאמת גובה
            transform.SetPositionAndRotation(cameraTransform.position + (cameraTransform.forward * 0.3f) + new Vector3(0, 1.0f, 0), cameraTransform.rotation);
            transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        }
        else
        {
            Debug.LogError("Camera Transform is not assigned in PanelPositioner!");
        }
    }
}