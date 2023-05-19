using System.Collections;
using System.Collections.Generic;
using RayFire;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MoneyText : MonoBehaviour
{
    RayfireConnectivity _rayfire;
    TextMeshProUGUI _text;
    [SerializeField] Transform _graphic;
    int _moneyPerChange = 10;
    float _lastIntegrity = 100f;
    int _money = 0;
    Vector3 _startIconScale;

    private void Start() {
        _rayfire = FindObjectOfType<RayfireConnectivity>();

        _text = GetComponent<TextMeshProUGUI>();
        _startIconScale = _graphic.localScale;
    }

    private void FixedUpdate() {
        float currentIntegrity = _rayfire.AmountIntegrity;

        

        if (!Mathf.Approximately(_lastIntegrity, currentIntegrity))
        {
            float change = _lastIntegrity - currentIntegrity;
            _money += (int)(change * (float)_moneyPerChange);
            _text.text = _money.ToString() + "$";
            _lastIntegrity = currentIntegrity;
            Sequence seq = DOTween.Sequence();
            seq.Append(_graphic.DOScale(_startIconScale * 1.2f, 0.1f));
            seq.Append(_graphic.DOScale(_startIconScale , 0.1f));
            
        }
    }


}
