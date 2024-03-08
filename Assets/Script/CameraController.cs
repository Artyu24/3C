using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public Camera _camera;
    private CameraConfiguration _cameraConfig = new CameraConfiguration();
    public List<AView> _activeViews = new List<AView>();

    private float speed = 5;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    void ApplyConfiguration(Camera camera, CameraConfiguration configuration)
    {
        camera.transform.rotation = configuration.GetRotation();
        camera.transform.position = configuration.GetPosition();
        camera.fieldOfView = configuration._fov;
    }

    public void AddView(AView view) => _activeViews.Add(view);
    public void RemoveView(AView view) => _activeViews.Remove(view);

    public float ComputeAverageYaw()
    {
        Vector2 sum = Vector2.zero;
        foreach (AView view in _activeViews)
        {
            CameraConfiguration config = view.GetConfiguration();
            sum += new Vector2(Mathf.Cos(config._yaw * Mathf.Deg2Rad), Mathf.Sin(config._yaw * Mathf.Deg2Rad)) * view._weight;
        }
        return Vector2.SignedAngle(Vector2.right, sum);
    }

    private void Smooth(Vector3 T)
    {
        Vector3 P = _camera.transform.position;

        if (speed * Time.deltaTime < 1)
            _camera.transform.position = P + (T - P) * speed * Time.deltaTime;
        else
            _camera.transform.position = T;
    }

    private void Update()
    {
        _cameraConfig._yaw = ComputeAverageYaw();
        ApplyConfiguration(_camera, _cameraConfig);
    }

    private void OnDrawGizmos()
    {
        _cameraConfig.DrawGizmos(Color.red);
    }
}
