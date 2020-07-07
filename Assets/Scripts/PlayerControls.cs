using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerModes
{
    Passive,
    Attract,
    Repel
}

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PlayerControls : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    public event Action<PlayerModes> OnPlayerSwitchedMode;
    public PlayerModes Mode { get; private set; } = PlayerModes.Passive;

    private void Awake()
    {
    }

    private void OnEnable()
    {
        var input = FindObjectOfType<PlayerInput>();
        if (input != null)
            input.OnChangeClickState += ChangeMode;
    }

    private void OnDisable()
    {
        var input = FindObjectOfType<PlayerInput>();
        if(input != null)
            input.OnChangeClickState -= ChangeMode;
    }

    public void ChangeMode(PlayerInput.PlayerInputState mode)
    {       
        switch (mode)
        {
            case PlayerInput.PlayerInputState.Right:
                if (Mode != PlayerModes.Repel)
                {
                    _playerMovement.StartCollectingEnergy(Mode);
                    Mode = PlayerModes.Repel;
                    OnPlayerSwitchedMode?.Invoke(Mode);
                }
                break;
            case PlayerInput.PlayerInputState.Left:
                if (Mode != PlayerModes.Attract)
                {
                    _playerMovement.StartCollectingEnergy(Mode);
                    Mode = PlayerModes.Attract;
                    OnPlayerSwitchedMode?.Invoke(Mode);
                }
                break;
            default:
                _playerMovement.EndCollectingEnergy(Mode);
                Mode = PlayerModes.Passive;
                OnPlayerSwitchedMode?.Invoke(Mode);
                break;         
        }    
    }

    public int GetMultiplierFromMode()
    {
        switch (Mode)
        {
            case PlayerModes.Attract:
                return 1;
            case PlayerModes.Repel:
                return -1;
            default:
                return 0;
        }
    }
    public int GetMultiplierFromMode(PlayerModes mode)
    {
        switch (mode)
        {
            case PlayerModes.Attract:
                return 1;
            case PlayerModes.Repel:
                return -1;
            default:
                return 0;
        }
    }
}
