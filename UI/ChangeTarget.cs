using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChangeTarget : MonoBehaviour
{
    [SerializeField] GameObject[] _targets;

    public void ActivateTarget(int index)
    {
        _targets.ToList().ForEach(x => x.SetActive(false));
        _targets[index].SetActive(true);
        FindObjectOfType<DebrisTrigger>().UpdateRayfire();
    }
}
