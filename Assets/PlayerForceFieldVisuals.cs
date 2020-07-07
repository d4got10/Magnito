using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForceFieldVisuals : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;

    [SerializeField] private PlayerControls _playerControls;

    [SerializeField] private Material _yellowMaterial;
    [SerializeField] private Material _greenMaterial;
    [SerializeField] private Material _redMaterial;

    private void Awake()
    {
        _playerControls.OnPlayerSwitchedMode += OnPlayerChangeMode;
    }

    public void OnPlayerChangeMode(PlayerModes mode)
    {
        switch (mode)
        {
            case PlayerModes.Attract:
                _meshRenderer.sharedMaterial = _greenMaterial;
                break;
            case PlayerModes.Repel:
                _meshRenderer.sharedMaterial = _redMaterial;
                break;
            case PlayerModes.Passive:
                _meshRenderer.sharedMaterial = _yellowMaterial;
                break;
        }
    }
}
