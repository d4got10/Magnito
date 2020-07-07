using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlsVisuals : MonoBehaviour
{
    [SerializeField] private PlayerControls _playerControls;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Coroutine _usingAbilityCoroutine;

    private void Awake()
    {
        _playerControls.OnPlayerSwitchedMode += OnPlayerUsingControls;    
    }

    public void OnPlayerUsingControls(PlayerModes mode)
    {
        if(mode == PlayerModes.Passive)
        {
            transform.localScale = new Vector3(0,0,1);
            _spriteRenderer.enabled = false;
            if(_usingAbilityCoroutine != null) StopCoroutine(_usingAbilityCoroutine);
        }
        else
        {
            if (_usingAbilityCoroutine != null) StopCoroutine(_usingAbilityCoroutine);
            _usingAbilityCoroutine = StartCoroutine(UsingAbilityCoroutine());
        }
    }

    IEnumerator UsingAbilityCoroutine()
    {
        _spriteRenderer.enabled = true;
        for (float t = 0; t < 5f; t += Time.deltaTime)
        {
            transform.localScale = new Vector3(t, t, 1);
            yield return null;
        }
    }
}
