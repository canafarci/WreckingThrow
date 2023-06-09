using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RayFire;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DebrisTrigger : MonoBehaviour
{
    public RayfireConnectivity Rayfire { get { return _rayfire; } }
    [SerializeField] TextMeshProUGUI _text;
    RayfireConnectivity _rayfire;
    [SerializeField] GameObject _endCanvas, _endFX;
    [SerializeField] Slider _slider;

    public void UpdateRayfire()
    {
        _rayfire = FindObjectOfType<RayfireConnectivity>();
    }
    private void Update()
    {
        if (_rayfire == null) { return; }

        float integrity = _rayfire.AmountIntegrity;
        _slider.value = (100f - integrity) / 100f;
        _text.text = (100f - integrity).ToString("F0") + "%";

        if (integrity < 35f)
        {
            Invoke("EnableEndCanvas", 5f);
            GameManager.Instance.CameraController.ActivateCamera("ThirdCamera");
            FindObjectOfType<Reference>().GameIsOver = true;
            _slider.value = 1f;
            _text.text = "100%";
            this.enabled = false;
        }
    }

    void EnableEndCanvas()
    {
        _endCanvas.SetActive(true);
        _endFX.SetActive(true);
        IncrementTargetIndex();
    }

    void IncrementTargetIndex()
    {
        int maxIndex = FindObjectOfType<GameStartSetTarget>().Targets.Length - 1;
        int currentIndex = PlayerPrefs.GetInt("Target");
        int newIndex = currentIndex + 1 > maxIndex ? 0 : currentIndex + 1;

        PlayerPrefs.SetInt("Target", newIndex);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
