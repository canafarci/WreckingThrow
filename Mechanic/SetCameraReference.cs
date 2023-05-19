using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraReference : MonoBehaviour
{
    Reference _references;
    private void Awake() {
        _references = FindObjectOfType<Reference>();
    }

    private void Start() {
        _references.SecondCam.m_Follow = transform;
        _references.SecondCam.m_LookAt = transform;
    }
}
