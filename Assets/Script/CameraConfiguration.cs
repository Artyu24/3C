using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraConfiguration
{
    public float _yaw;
    public float _pitch;
    public float _roll;
    public Vector3 _pivot;
    public float _distance;
    public float _fov = 90;

    public Quaternion GetRotation()
    {
        return Quaternion.Euler(_pitch, _yaw, _roll);
    }

    public Vector3 GetPosition()
    {
        Vector3 offset = GetRotation() * (Vector3.back * _distance);
        return _pivot + offset;
    }

    public void DrawGizmos(Color color)
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(_pivot, 0.25f);
        Vector3 position = GetPosition();
        Gizmos.DrawLine(_pivot, position);
        Gizmos.matrix = Matrix4x4.TRS(position, GetRotation(), Vector3.one);
        Gizmos.DrawFrustum(Vector3.zero, _fov, 0.5f, 0f, Camera.main.aspect);
        Gizmos.matrix = Matrix4x4.identity;
    }
}
