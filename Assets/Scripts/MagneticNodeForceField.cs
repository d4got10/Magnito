using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class MagneticBlockForceField : MonoBehaviour
{
    /*[SerializeField] private Color _magneticFieldColorAttractor;
    [SerializeField] private Color _magneticFieldColorRepeler;
    [SerializeField] private Color _magneticFieldColorDisabled;

    public float ForceFieldRadius;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnParentNodeChanged(Magnet parentNode)
    {
        transform.localScale = new Vector3(parentNode.ForceFieldRadius * 2, parentNode.ForceFieldRadius * 2, 1);
        switch (parentNode.Type)
        {
            case MagneticNode.MagneticNodesType.Attractor:
                _spriteRenderer.color = _magneticFieldColorAttractor;
                break;
            case MagneticNode.MagneticNodesType.Repeler:
                _spriteRenderer.color = _magneticFieldColorRepeler;
                break;
            case MagneticNode.MagneticNodesType.Disabled:
                _spriteRenderer.color = _magneticFieldColorDisabled;
                break;
        }
    }*/
}
