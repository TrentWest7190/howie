using UnityEngine;

public class AddCameraController : MonoBehaviour
{
    public GameObject monitors;

    public Camera directorCam;
    void setCameraToMain(Camera cam) {
        cam.transform.position = Camera.main.transform.position;
        cam.transform.rotation = Camera.main.transform.rotation;
    }

    void DropCamera(string cameraName) {
        GameObject cameraContainer = transform.Find(cameraName).gameObject;
            Camera screenCamera = cameraContainer.transform.Find("ScreenCamera").GetComponent<Camera>();
            Camera monitorCamera = cameraContainer.transform.Find("MonitorCamera").GetComponent<Camera>();
            setCameraToMain(monitorCamera);
            setCameraToMain(screenCamera);
            monitorCamera.enabled = true;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) return;
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            DropCamera("Camera 1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            DropCamera("Camera 2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            DropCamera("Camera 3");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0)) {
            Camera.main.enabled = false;
            directorCam.gameObject.tag = "MainCamera";
            Camera.main.gameObject.tag = "Untagged";
            directorCam.enabled = true;
        }
    }
}
