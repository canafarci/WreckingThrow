using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ThrowBall : MonoBehaviour
{
    [SerializeField] float _height, _duration, _throwDelay, _followDisableDelay;
    [SerializeField] float _secondCameraDelay = 0.5f;
    [SerializeField] AnimationCurve _customEase;
    [SerializeField] Renderer _r1, _r2;
    [SerializeField] GameObject _chainFx1, _chainFx2;
    ParticleSystem _fx;
    Transform _parent;
    SpawnPlayer _spawner;
    Animator _animator;
    Transform _target;
    Targets _targets;
    Reference _references;
    DistanceText _distanceText;
    Vector3 _startPos;

    public event Action BallThrownHandler;
    bool _hasStarted = false;

    private void Awake()
    {
        _references = FindObjectOfType<Reference>();
    }

    private void Start()
    {
        SetReferences();

        Transform[] targets = _targets.ThrowTargets;
        _target = targets[_references.ThrowCount];

        FindObjectOfType<InputReader>().PointerHandler += OnTouchScreen;

        _animator = _references.Animator;
        _fx = _references.FX;
        _parent = GameObject.FindGameObjectWithTag("Player").transform;
        _references.StatsPopup.SetActive(false);

        StartCoroutine(ResetCamera());


        _references.FirstCam.m_Follow = _parent;
        _references.FirstCam.m_LookAt = _parent;



        _references.CanThrow = true;
    }

    IEnumerator ResetCamera()
    {
        GameManager.Instance.CameraController.ActivateCamera("FirstCamera");
        _animator.Play("CameraAnimation", -1, 0.0f);
        yield return new WaitForEndOfFrame();
        _animator.enabled = false;
        yield return new WaitForEndOfFrame();
    }

    private void OnDisable()
    {
        InputReader pc = FindObjectOfType<InputReader>();
        if (pc != null)
            pc.PointerHandler -= OnTouchScreen;
    }

    private void SetReferences()
    {
        _targets = FindObjectOfType<Targets>();
        _spawner = FindObjectOfType<SpawnPlayer>();
        _distanceText = _references.DistanceText;

        _startPos = transform.position;
        _distanceText.StartPos = _startPos;
        _distanceText.Ball = transform;
    }

    private void OnTouchScreen(bool pressed)
    {
        if (!pressed && _references.CanThrow)
        {
            Invoke("Throw", _throwDelay);
            _references.DebrisFX.Play();
            _references.CanThrow = false;

        }
        else if (pressed && _references.CanThrow)
        {
            _animator.enabled = true;
            _animator.Play("CameraAnimation", -1, 0.0f);
        }
    }

    private void Throw()
    {
        _references.ThrowCount++;
        transform.SetParent(null);
        transform.LookAt(_target);

        _references.Resetter2.Reset();

        _r1.enabled = false;
        _r2.enabled = true;

        _chainFx1.SetActive(true);
        _chainFx2.SetActive(false);

        _references.StatsPopup.SetActive(true);

        Vector3 targetPos = _target.transform.position;
        targetPos.y = 0.55f;
        _target.transform.position = targetPos;

        _target.transform.SetParent(null);
        transform.DOMove(_target.position, _duration).SetEase(Ease.Linear);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.GetChild(0).DOMoveY(_height, _duration / 2f));
        sequence.Append(transform.GetChild(0).DOMoveY(0.55f, _duration / 2f));

        sequence.SetEase(_customEase);

        sequence.OnComplete(() =>
        { //ActivateFinalCamera();
            _fx.gameObject.SetActive(false);
            BallThrownHandler?.Invoke();
            Destroy(gameObject, 0.1f);
            Destroy(_parent.gameObject);
            _spawner.Spawn();
        });

        Invoke("RemoveSecondCameraFollow", _followDisableDelay);

        Invoke("ActivateSecondCamera", _secondCameraDelay);
    }

    void RemoveSecondCameraFollow()
    {
        _references.SecondCam.m_Follow = null;
        _references.SecondCam.m_LookAt = null;
    }

    void ActivateSecondCamera()
    {
        GameManager.Instance.CameraController.ActivateCamera("SecondCamera");
        _fx.gameObject.SetActive(true);
    }

    void ActivateFinalCamera()
    {
        GameManager.Instance.CameraController.ActivateCamera("ThirdCamera");
        _fx.gameObject.SetActive(false);
    }
}
