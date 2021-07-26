using UnityEngine;

public class DirectorController : MonoBehaviour
{
    Camera currentCamera;
    void Start() {
        currentCamera = Camera.main;
    }

    void CutToCamera(string cameraName) {
        GameObject cameraObj = transform.Find(cameraName).Find("ScreenCamera").gameObject;
        cameraObj.tag = "MainCamera";
        currentCamera.gameObject.tag = "Untagged";

        Camera nextCamera = cameraObj.GetComponent<Camera>();
        nextCamera.enabled = true;
        currentCamera.enabled = false;
        currentCamera = nextCamera;
    }
    void Update()
    {
        if (!Input.GetKey(KeyCode.LeftShift)) return;
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            CutToCamera("Camera 1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            CutToCamera("Camera 2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            CutToCamera("Camera 3");
        }
    }
}
