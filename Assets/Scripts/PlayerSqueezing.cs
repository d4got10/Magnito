using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSqueezing : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private PlayerTrail _trail;

    private Vector3 _normalSize;
    private Vector3 _targetSize;

    private void Awake()
    {
        _normalSize = transform.localScale;    
    }

    private void Update()
    {
        float xSize = _normalSize.x * Mathf.Clamp(9f * 0.8f / Mathf.Abs(_rigidbody.velocity.y + .001f), 0.3f, 1);
        float ySize = _normalSize.y * Mathf.Clamp(9f * 0.8f / Mathf.Abs(_rigidbody.velocity.x + .001f), 0.3f, 1);

        _trail.Width = Mathf.Min(xSize, ySize);

        _targetSize = new Vector3(xSize, ySize);

        transform.localScale = Vector3.Lerp(transform.localScale, _targetSize, 0.1f);    
    }
}
