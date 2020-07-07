using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizer : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private PlayerMovement _playerMovement;

    private float _normalSize;
    private void Awake()
    {
        _normalSize = _camera.orthographicSize;
    }

    private void Update()
    {
        float targetSize = _normalSize * (1 - .4f * (_playerMovement.Energy / _playerMovement.EnergyMaximum));
        _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize,  targetSize, 0.05f); 
    }
}
