using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollZoom : MonoBehaviour
{
    float velocity = 0.0f;
    float endFOV;

    [Range(1,100)]
    public float jumpBy = 20.0f;

    [Range(0.1f,2)]
    public float smoothTime = 1.0f;
    void Start()
    {
        endFOV = Camera.main.fieldOfView;
    }

    void Update()
    {
        float mouseDelta = Input.mouseScrollDelta.y;
        float m_FieldOfView = Camera.main.fieldOfView;

        if (mouseDelta != 0) {
            Debug.Log(mouseDelta);
            endFOV = m_FieldOfView - (mouseDelta * jumpBy);
        }

        float newFOV = Mathf.SmoothDamp(m_FieldOfView, endFOV, ref velocity, smoothTime);
        Camera.main.fieldOfView = newFOV;
    }
}