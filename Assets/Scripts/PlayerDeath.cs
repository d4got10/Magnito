using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour, IDamageable
{
    [SerializeField] private List<MonoBehaviour> _componentsToDisable;
    [SerializeField] private List<GameObject> _objectsToDisable;
    [SerializeField] private List<GameObject> _objectsToEnable;

    public UnityEvent OnPlayerDeath;
    public UnityEvent OnPlayerDeathVisuals;

    private void Awake()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage();
    }

    public void TakeDamage()
    {
        if (enabled)
        {
            foreach (var component in _componentsToDisable)
                component.enabled = false;

            foreach (var gameObjectToDisable in _objectsToDisable)
                gameObjectToDisable.SetActive(false);

            foreach (var gameObjectToEnable in _objectsToEnable)
                gameObjectToEnable.SetActive(true);

            OnPlayerDeathVisuals?.Invoke();
            StartCoroutine(DelayedInvoke(3));
        }
    }

    IEnumerator DelayedInvoke(float time)
    {
        for(float t = 0.8f; t < 0.8f + time; t += Time.unscaledDeltaTime)
        {
            Time.timeScale = Mathf.Clamp(1 / (t*t), 0.35f, 1);
            yield return null;
        }
        Time.timeScale = 1;
        OnPlayerDeath?.Invoke();
    }
}
