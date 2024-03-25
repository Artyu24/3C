using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollyView : AView
{
    public float _roll;
    public float _distance;
    public float _fov;
    public Vector3 _target;
    public Rail _rail;
    private float _distanceOnRail;
    public float _speed;

    private void Update()
    {
        Camera.main.transform.LookAt(_target);

        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D))
        {
            float axis = Input.GetAxis("Horizontal");
            _distanceOnRail += axis * _speed * Time.deltaTime;
            Camera.main.transform.position = _rail.GetPosition(_distanceOnRail);
        }
    }
}
