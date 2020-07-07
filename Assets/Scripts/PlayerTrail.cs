using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrail : MonoBehaviour
{
    [SerializeField] private PlayerControls _playerControls;
    [SerializeField] private TrailRenderer _trailRenderer;

    public float Width = 1;

    private void Awake()
    {
        _playerControls.OnPlayerSwitchedMode += ChangeColor;      
    }


    private void Update()
    {
        _trailRenderer.startWidth = Width;
    }

    public void ChangeColor(PlayerModes mode)
    {
        switch (mode)
        {
            case PlayerModes.Attract:
                _trailRenderer.startColor = Color.green;
                break;
            case PlayerModes.Repel:
                _trailRenderer.startColor = Color.red;
                break;
            default:
                _trailRenderer.startColor = Color.yellow;
                break;
        }
    }

    
}
