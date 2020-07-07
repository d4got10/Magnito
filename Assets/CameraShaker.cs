using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Shake()
    {
        _animator.SetTrigger("Shake");
    }

    public void DeadShake()
    {
        _animator.SetTrigger("DeadShake");
    }
}
