using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBlockAnimation : MonoBehaviour
{
    [SerializeField] private Animation _animation;
    [SerializeField] private FinishBlock _finishBlock;

    private void OnEnable()
    {
        _finishBlock.OnLevelComplete += StartAnimation;
    }

    private void OnDisable()
    {
        _finishBlock.OnLevelComplete -= StartAnimation;
    }

    public void StartAnimation()
    {
        _animation.Play();
    }
}
