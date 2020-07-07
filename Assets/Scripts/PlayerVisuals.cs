using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private PlayerControls _playerControls;

    [SerializeField] private Sprite _attractorModeSprite;
    [SerializeField] private Sprite _repellerModeSprite;
    [SerializeField] private Sprite _disabledModeSprite;

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
                _spriteRenderer.sprite = _attractorModeSprite;
                break;
            case PlayerModes.Repel:
                _spriteRenderer.sprite = _repellerModeSprite;
                break;
            default:
                _spriteRenderer.sprite = _disabledModeSprite;
                break;
        }
    }
}
