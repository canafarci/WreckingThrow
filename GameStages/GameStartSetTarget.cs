using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStartSetTarget : MonoBehaviour
{
    public GameObject[] Targets { get { return _targets; } }
    DebrisTrigger _trigger;
    [SerializeField] GameObject[] _targets;

    private void Awake()
    {
        _trigger = FindObjectOfType<DebrisTrigger>();
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Target"))
            PlayerPrefs.SetInt("Target", 0);

        ActivateTarget(PlayerPrefs.GetInt("Target"));
    }

    public void ActivateTarget(int index)
    {
        _targets.ToList().ForEach(x => x.SetActive(false));
        _targets[index].SetActive(true);
        FindObjectOfType<DebrisTrigger>().UpdateRayfire();
    }
}
