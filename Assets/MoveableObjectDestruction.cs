using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObjectDestruction : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private PlayerLightVisuals _playerLightVisuals;

    public void OnDestruction()
    {
        ParticleSystem.MainModule main = _particleSystem.main;
        main.startColor = _playerLightVisuals.LightColor;
        _particleSystem.Play();
        StartCoroutine(DestroyCoroutine());
    }

    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
