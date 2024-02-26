using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AView : MonoBehaviour
{
    public bool _isActiveOnStart;
    public float _weight;

    private void Start()
    {
        if (_isActiveOnStart)
            SetActive(_isActiveOnStart);
    }

    public virtual CameraConfiguration GetConfiguration()
    {
        return new CameraConfiguration();
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
