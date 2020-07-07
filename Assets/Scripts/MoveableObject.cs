using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MoveableObject : MonoBehaviour, IDamageable
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private LayerMask _objectsThatCanBePassedLayer;

    public float Speed = 5;
    public Action<MoveableObject> AddForce;

    public UnityEvent OnDestruction;

    public Vector2 PositionInGrid
    {
        get
        {
            var position = new Vector2();
            position.x = Mathf.Round(transform.position.x);
            position.y = Mathf.Round(transform.position.y);
            return position;
        }
    }

    public bool Simulated = true;
    public bool Attractable = true;

    public Vector2 ResultForce = new Vector2();

    private void FixedUpdate()
    {
        if (Simulated)
        {
            AddForce?.Invoke(this);
            if(ClampVector(ResultForce * (Attractable ? 1 : -1)).sqrMagnitude > 0)
                _rigidbody.velocity = ClampVector(ResultForce * (Attractable ? 1 : -1));
            ResultForce = new Vector2();
        }
        else
        {
            if (_rigidbody.velocity.magnitude < 1f)
                _rigidbody.velocity = Vector2.zero;
        }
        if (_rigidbody.velocity.magnitude < 0.01f)
        {
            _rigidbody.position = PositionInGrid;
        }
        else
        {
            if (Mathf.Abs(_rigidbody.velocity.x) > 0)
                _rigidbody.position += new Vector2(0, PositionInGrid.y - _rigidbody.position.y);
            else if (Mathf.Abs(_rigidbody.velocity.y) > 0)
                _rigidbody.position += new Vector2(PositionInGrid.x - _rigidbody.position.x, 0);
        }
    }

    private Vector2 ClampVector(Vector2 vectorIn)
    {
        Vector2 vector = vectorIn;

        ContactFilter2D filter = new ContactFilter2D();
        filter.NoFilter();
        filter.useTriggers = false;
        filter.useLayerMask = true;
        filter.layerMask = _objectsThatCanBePassedLayer;

        List<RaycastHit2D> hits = new List<RaycastHit2D>();
        Physics2D.Raycast(transform.position, transform.right * (vector.x >= 0 ? 1 : -1), filter, hits, 0.6f);

        if (hits != null && hits.Count > 0)
        {
            vector.x = 0;
        }
        hits.Clear();
        Physics2D.Raycast(transform.position, transform.up * (vector.y >= 0 ? 1 : -1), filter, hits, 0.6f);
        if (hits != null && hits.Count > 0)
        {
            vector.y = 0;
        }

        if (Mathf.Abs(vector.x) > Mathf.Abs(vector.y))
            vector.y = 0;
        else
            vector.x = 0;

        vector.Normalize();

        vector *= Speed;

        return vector;
    }

    public void TakeDamage()
    {
        OnDestruction.Invoke();
    }
}
