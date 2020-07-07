using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShaking : MonoBehaviour
{
    [SerializeField] private PlayerControls _playerControls;
    [SerializeField] private CameraShaker _cameraShaker;


    //ADD DEADSHAKE

    private void OnEnable()
    {
        if (_playerControls != null) _playerControls.OnPlayerSwitchedMode += OnSwitchedMode;
    }

    private void OnDisable()
    {
        if (_playerControls != null) _playerControls.OnPlayerSwitchedMode -= OnSwitchedMode;
    }

    public void OnSwitchedMode(PlayerModes mode)
    {
        _cameraShaker.Shake();
    }
}
