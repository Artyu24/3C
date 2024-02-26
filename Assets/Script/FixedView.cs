using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedView : AView
{
    public float _yaw;
    public float _pitch;
    public float _roll;
    public float _fov;

    public override CameraConfiguration GetConfiguration()
    {
        CameraConfiguration config = base.GetConfiguration();

        config._yaw = _yaw;
        config._pitch = _pitch;
        config._roll = _roll;
        config._fov = _fov;
        config._pivot = transform.position;
        config._distance = 0;

        return config;
    }
}
