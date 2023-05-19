using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateButton : MonoBehaviour
{
    [SerializeField] GameObject _target;
    public void OnButtonPress()
    {
        _target.SetActive(!_target.activeSelf);
    }
}
