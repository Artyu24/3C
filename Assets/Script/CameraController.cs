using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public Camera _camera;
    private CameraConfiguration _cameraConfig = new CameraConfiguration();
    private List<AView> _activeViews = new List<AView>();

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

    private void OnDrawGizmos()
    {
        _cameraConfig.DrawGizmos(Color.red);
    }
}
