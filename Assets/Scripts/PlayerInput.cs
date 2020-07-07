using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //public static PlayerInput _instance = null;

    public event Action<PlayerInputState> OnChangeClickState;

    public enum PlayerInputState
    {
        None,
        Right,
        Left
    }
    private PlayerInputState _clickState = PlayerInputState.None;


    public void OnRightInput(bool state)
    {
        if (state) 
            CheckChanges(PlayerInputState.Right);
        else if (_clickState == PlayerInputState.Right) 
            CheckChanges(PlayerInputState.None);
    }

    public void OnLeftInput(bool state)
    {
        if (state)
            CheckChanges(PlayerInputState.Left);
        else if (_clickState == PlayerInputState.Left)
            CheckChanges(PlayerInputState.None);
    }

    private void CheckChanges(PlayerInputState type)
    {
        if (_clickState != type)
        {
            _clickState = type;
            OnChangeClickState?.Invoke(_clickState);
        }
    }
}
