using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChangeColor : MonoBehaviour
{
    Reference _references;
    float _duration;

    private void Awake() {
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
                ChangeColorTween();
            }

    }

    private void ChangeColorTween()
    {
        Color color = GameManager.Instance.References.GameConfig.RedColor;
        Sequence seq = DOTween.Sequence();
        seq.PrependInterval(2);
        seq.Append(GetComponent<Renderer>().material.DOColor(color, _duration));
    }
}
