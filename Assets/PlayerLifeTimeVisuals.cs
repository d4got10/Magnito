using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeTimeVisuals : MonoBehaviour
{
    [SerializeField] private PlayerLifeTime _playerLifeTime;
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        _slider.maxValue = _playerLifeTime.MaxTime;
        _slider.minValue = 0;
    }

    private void Update()
    {
        _slider.value = _playerLifeTime.RemainingTime;
    }
}
