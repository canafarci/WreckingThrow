using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomizeValues : MonoBehaviour
{
    TextMeshProUGUI _text;
    [SerializeField] int _minRange, _maxRange;
    [SerializeField] string _suffix;
    private void Awake() => _text = GetComponent<TextMeshProUGUI>();

    private void OnEnable() {
        int randomValue = Random.Range(_minRange, _maxRange);

        _text.text = randomValue.ToString() + _suffix;
    }
}
