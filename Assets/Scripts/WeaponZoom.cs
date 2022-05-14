using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField]Camera FPSCam;
    [SerializeField]float zoomedOut = 65f;
    [SerializeField]float zoomedIn = 45f;
    [SerializeField]float zoomedOutSensitivity = 2f;
    [SerializeField]float zoomedInSensitivity = 1f;

    RigidbodyFirstPersonController fpsController;
    bool isZoomedIn = false;

    void Start() {
        fpsController = GetComponent<RigidbodyFirstPersonController>();
    }

    void Update() {
        if(Input.GetMouseButtonDown(1)) {
            if(isZoomedIn) {
                FPSCam.fieldOfView = zoomedOut;
                isZoomedIn = false;
                fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
                fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
            }
            else {
                FPSCam.fieldOfView = zoomedIn;
                isZoomedIn = true;
                fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
                fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
            }
        }
    }
}
