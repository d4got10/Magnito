using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Magnet : Block, ISwitchable
{
    [SerializeField] private int _magneticFieldRadius;
    [SerializeField] private MagneticField _magneticField;
    [SerializeField] private LayerMask _objectsExeptMagnetsLayerMask;

    public int MagneticFieldRadius { get { return _magneticFieldRadius; } }
    public LayerMask ObjectsToBoundMagneticFieldLayerMask { get { return _objectsExeptMagnetsLayerMask; } }

    private List<MoveableObject> _moveableObjects = new List<MoveableObject>();

    public abstract int GetMultiplierFromType();
    public abstract void TurnOn(ISwitchable parent);
    public abstract void TurnOff(ISwitchable parent);

    public override void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        _magneticField.OnObjectEnter += OnObjectEnter;
        _magneticField.OnObjectExit += OnObjectExit;
    }

    private void OnDisable()
    {
        _magneticField.OnObjectEnter -= OnObjectEnter;
        _magneticField.OnObjectExit -= OnObjectExit;
    }

    public override void Setup()
    {
        base.Setup();
        _magneticField.UpdateField();
        _magneticField.Parent = this;
    }

    public void OnObjectEnter(MoveableObject enteredObject)
    {
        if (!_moveableObjects.Contains(enteredObject))
        {
            _moveableObjects.Add(enteredObject);
            enteredObject.AddForce += AddForce;
        }
    }

    public void OnObjectExit(MoveableObject enteredObject)
    {
        if (_moveableObjects.Contains(enteredObject))
        {
            _moveableObjects.Remove(enteredObject);
            enteredObject.AddForce -= AddForce;
        }
    }

    public void AddForce(MoveableObject moveableObject)
    {
        if (PositionInGrid.x == moveableObject.PositionInGrid.x)
        {
            Vector2 forceDirection = new Vector2(0, moveableObject.transform.position.y - PositionInGrid.y);
            forceDirection *= GetMultiplierFromType();
            moveableObject.ResultForce += (forceDirection.normalized * _magneticFieldRadius -  forceDirection);
        }
        if(PositionInGrid.y == moveableObject.PositionInGrid.y)
        {
            Vector2 forceDirection = new Vector2(moveableObject.transform.position.x - PositionInGrid.x, 0);
            forceDirection *= GetMultiplierFromType();
            moveableObject.ResultForce += (forceDirection.normalized * _magneticFieldRadius - forceDirection);
        }
    }
}
