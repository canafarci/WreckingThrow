using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] int _spinCount;
    float _duration;
    Sequence sequence;
    private void Awake() {
        _duration = GameManager.Instance.References.GameConfig.ThrowDuration;
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

    private void Start() {
        sequence = DOTween.Sequence();

        int totalIndex = 0;

        for (int i = 0; i < _spinCount; i++)
        {
            totalIndex += (i + 1);
        }

        for (int i = 0; i < _spinCount; i++)
        {
            sequence.Append(transform.DOLocalRotate(new Vector3(0, 360, 0), (_duration / (totalIndex)) * (_spinCount - i), RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear));
        }
    }

    private void OnTouchScreen(bool pressed)
    {
        if (pressed)
            sequence.Kill();
    }
    
}
