using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerEnergy : MonoBehaviour
{
    public int MaxEnergy;
    public int Energy { get; private set; }

    public event Action<int> OnEnergyChanged;
    public event Action OnOutOfEnergy;

    private void Awake()
    {
        Energy = MaxEnergy;
        OnEnergyChanged?.Invoke(Energy);
    }

    private void OnEnable()
    {
        var input = FindObjectOfType<PlayerControls>();
        if (input != null)
            input.OnPlayerSwitchedMode += OnPlayerSwitchedMode;
    }

    private void OnDisable()
    {
        var input = FindObjectOfType<PlayerControls>();
        if (input != null)
            input.OnPlayerSwitchedMode -= OnPlayerSwitchedMode;
    }

    public void OnPlayerSwitchedMode(PlayerModes mode)
    {
        if (mode == PlayerModes.Passive) return;

        SpendEnergy();
    }

    private void SpendEnergy()
    {
        Energy--;
        OnEnergyChanged?.Invoke(Energy);
        if (Energy < 1)
        {
            OnOutOfEnergy?.Invoke();
            Energy = 0;
        }       
    }
}
