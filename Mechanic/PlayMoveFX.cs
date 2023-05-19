using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMoveFX : MonoBehaviour
{
    [SerializeField] ParticleSystem _fx;
    Reference _references;
    float _duration;

    private void Awake()
    {
        _duration = GameManager.Instance.References.GameConfig.ThrowDuration;
        _references = FindObjectOfType<Reference>();
    }
    private void OnEnable()
    {
        FindObjectOfType<InputReader>().PointerHandler += OnTouchScreen;
    }

    private void OnDisable()
    {
        InputReader pc = FindObjectOfType<InputReader>();
        if (pc != null)
            pc.PointerHandler -= OnTouchScreen;
    }

    private void OnTouchScreen(bool pressed)
    {
        if (pressed && _references.CanThrow)
        {
            Invoke("PlayFX", 2f);
        }
    }

    private void PlayFX()
    {
        _fx.Play();
    }
}
