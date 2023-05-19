using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCheerAnim : MonoBehaviour
{
    string[] _anims = new string[] {"CLAP", "CHEER_1", "CHEER_2", "CHEER_3"};
    private void OnEnable()
    {
        FindObjectOfType<ThrowBall>().BallThrownHandler += OnBallThrown;
    }

    private void OnDisable()
    {
        ThrowBall tb = FindObjectOfType<ThrowBall>();
        if (tb != null)
            tb.BallThrownHandler -= OnBallThrown;
    }

    private void OnBallThrown()
    {
        int randInt = UnityEngine.Random.Range(0, 3);
        GetComponent<Animator>().Play(_anims[randInt]);
    }
}
