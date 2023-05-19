using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneButton : MonoBehaviour
{
    public void LoadScene(int index)
    {
        GameManager.Instance.SceneLoader.LoadScene(index);
    }
}
