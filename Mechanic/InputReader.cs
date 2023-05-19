using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputReader : MonoBehaviour
{
    public event Action<bool> PointerHandler;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !CheckPointer.IsPointerOverGameObject())
        {
            PointerHandler?.Invoke(true);
        }
        if (Input.GetMouseButtonUp(0) && !CheckPointer.IsPointerOverGameObject())
        {
            PointerHandler?.Invoke(false);
        }
    }

}
