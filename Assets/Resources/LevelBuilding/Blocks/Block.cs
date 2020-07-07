using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    public Vector2 PositionInGrid;

    public virtual void Setup()
    {
        PositionInGrid = transform.position;
    }

    public virtual void Destroy()
    {
        Destroy(gameObject);
    }

    public abstract int GetId();
}
