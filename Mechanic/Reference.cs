using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Reference : MonoBehaviour
{
    public Animator Animator;
    public ParticleSystem FX, DebrisFX;
    public CinemachineVirtualCamera SecondCam, FirstCam;
    public ResetCamera  Resetter2;
    public int ThrowCount = 0;
    public bool CanThrow = true;
    public bool GameIsOver = false;
    public GameObject StatsPopup;
    public DistanceText DistanceText;
}
