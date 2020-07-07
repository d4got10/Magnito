using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public float FinalAnimation()
    {
        _animator.SetTrigger("FinalAnimation");
        return 1f;
    }
}
