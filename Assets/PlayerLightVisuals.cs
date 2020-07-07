using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightVisuals : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PlayerControls _playerControls;

    [SerializeField] private Color _attractorModeColor;
    [SerializeField] private Color _repellerModeColor;
    [SerializeField] private Color _disabledModeColor;

    public Color LightColor { get { return _spriteRenderer.color; } }

    private void OnEnable()
    {
        _playerControls.OnPlayerSwitchedMode += ChangeSprite;
    }

    private void OnDisable()
    {
        _playerControls.OnPlayerSwitchedMode -= ChangeSprite;
    }

    public void ChangeSprite(PlayerModes mode)
    {
        switch (mode)
        {
            case PlayerModes.Attract:
                _spriteRenderer.color = _attractorModeColor;
                break;
            case PlayerModes.Repel:
                _spriteRenderer.color = _repellerModeColor;
                break;
            default:
                _spriteRenderer.color = _disabledModeColor;
                break;
        }
    }
}
