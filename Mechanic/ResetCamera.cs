using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCamera : MonoBehaviour
{
    Vector3 _position;
    Quaternion _rotation;

    private void OnEnable() {
        _position = transform.position;
        _rotation = transform.rotation;
    }
    
    public void Reset()
    {
        transform.position = _position;
        transform.rotation = _rotation;
    }
}
