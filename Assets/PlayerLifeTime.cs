using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeTime : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerDeath _playerDeath;


    [SerializeField] private float _timeGainMultiplierWhenCharging = 2f;
    [SerializeField] private float _maxTime = 5f;
    public float MaxTime { get { return _maxTime; } }
    public float RemainingTime { get; private set; } = 0f;

    private void Awake()
    {
        RemainingTime = _maxTime;
    }

    private void Update()
    {
        if (_playerMovement.CollectsEnergy && _playerMovement.IsAffectingByField && (_playerMovement.Energy != _playerMovement.EnergyMaximum))
        {
            RemainingTime += _timeGainMultiplierWhenCharging * Time.deltaTime;
            if (RemainingTime > _maxTime)
            {
                RemainingTime = _maxTime;
            }
        }
        else
        {          
            RemainingTime -= Time.deltaTime;
            if (RemainingTime < 0)
            {
                RemainingTime = 0;
                _playerDeath.TakeDamage();
            }
        }
    }
}
