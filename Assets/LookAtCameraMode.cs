using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCameraMode : MonoBehaviour
{
    public enum Mode{
        LookAtCamera,
        LookAtCameraConvert,
        LookAtCameraForward,
        LookAtCameraForwardConvert,
        WorldForward
    }
    [SerializeField]private Mode mode;

    private void Update() {
        Camera mainCamera = Camera.main;
        if (mainCamera == null) return;

        switch (mode) {
            case Mode.LookAtCamera:
                transform.LookAt(mainCamera.transform);
                break;
            case Mode.LookAtCameraConvert:
                Vector3 direction = mainCamera.transform.position - transform.position;
                transform.rotation = Quaternion.LookRotation(direction);
                break;
            case Mode.LookAtCameraForward:
                transform.forward = mainCamera.transform.forward;
                break;
            case Mode.LookAtCameraForwardConvert:
                Vector3 forwardDirection = mainCamera.transform.forward;
                transform.forward = forwardDirection;
                break;
            case Mode.WorldForward:
                transform.forward = Vector3.forward;
                break;
            default:
                break;
        }
    }
}
