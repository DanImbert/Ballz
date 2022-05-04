using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] ARCameraManager manager;
    // Start is called before the first frame update
    public void ToggleCamera()
    {
        if (manager.currentFacingDirection == CameraFacingDirection.User)
        {
            manager.requestedFacingDirection = CameraFacingDirection.World;
        }
        else
        {
            manager.requestedFacingDirection = CameraFacingDirection.User;
        }
    }
}
