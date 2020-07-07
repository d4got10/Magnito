using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _target;
    [SerializeField] private bool _reactsToSpeed;

    private float _cameraNormalSize;
    private float _cameraTargetSize;
    private float _zOffset;
    private Rigidbody2D _targetsRigidbody;

    private void Awake()
    {
        _cameraNormalSize = _camera.orthographicSize;
        _zOffset = transform.position.z;
        _targetsRigidbody = _target.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.position = _target.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, _zOffset);
        if (_reactsToSpeed)
        {
            if (_targetsRigidbody)
            {
                _cameraTargetSize = _cameraNormalSize + _targetsRigidbody.velocity.magnitude / 20;
                _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, _cameraTargetSize, 0.1f);
            }
        }
    }
}
