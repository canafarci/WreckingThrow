using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceText : MonoBehaviour
{
    public Vector3 StartPos;
    public Transform Ball;
    TextMeshProUGUI _text;
    private void Awake() {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        Vector3 modStartPos = StartPos;
        modStartPos.y = 0;

        if (Ball == null) {return;}
        
        Vector3 modBallPos = Ball.position;
        modBallPos.y = 0;

        _text.text = Vector3.Distance(modStartPos, modBallPos).ToString("F0");
    }
}
