using System.Collections;
using System.Collections.Generic;
using CartoonFX;
using RayFire;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other) {
        if ((int)other.gameObject.layer == 4)
        {
        transform.GetChild(0).gameObject.SetActive(true);
        Invoke("DisableChild", 2f);
        }
    }

    void DisableChild()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
