using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedFollowView : AView
{
    public float roll;
    public float fov;

    public Vector3 target;

    [SerializeField] private GameObject centralPoint;
    [SerializeField] private float yawOffsetMax;
    [SerializeField] private float ptichOffsetMax;

    public void SetupCameraConfig()
    {
        Vector3 dir = target - transform.position;
        _cameraConfiguration._yaw = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        _cameraConfiguration._pitch = (Mathf.Asin(dir.y) * -1) * Mathf.Rad2Deg;
    }
}
