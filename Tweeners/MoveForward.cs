using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class MoveForward : MonoBehaviour
{
    public Transform Target;
    [SerializeField] float _stopDuration;
    [SerializeField] Ease _easeMode;
    Reference _references;
    Animator _animator;
    float _duration;

    private void Awake() {
        _duration = GameManager.Instance.References.GameConfig.ThrowDuration;
        _animator = GetComponentInChildren<Animator>();
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
                Move();
            }

        else if (!pressed)
        {
            transform.DOKill();
            _animator.SetTrigger("throw");
        }

    }

    void Move()
    {
        _animator.Play("Start");
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMove(transform.position, _stopDuration));
        sequence.Append(transform.DOLocalMove(Target.position, _duration - _stopDuration).SetEase(_easeMode));
    }
}
