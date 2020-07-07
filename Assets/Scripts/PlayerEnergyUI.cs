using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class PlayerEnergyUI : MonoBehaviour
{
    [SerializeField] private PlayerEnergy _playerEnergy;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _playerEnergy.MaxEnergy;
        _slider.value = _playerEnergy.Energy;
    }

    private void OnEnable()
    {
        _playerEnergy.OnEnergyChanged += ChangeSliderValue;
    }

    private void OnDisable()
    {
        _playerEnergy.OnEnergyChanged -= ChangeSliderValue;
    }

    public void ChangeSliderValue(int value)
    {
        _slider.value = value;
    }
}
