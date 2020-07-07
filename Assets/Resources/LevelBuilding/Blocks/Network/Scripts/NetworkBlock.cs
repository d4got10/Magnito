using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NetworkBlock : Block, ISwitchable
{
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;

    private List<ISwitchable> _parents = new List<ISwitchable>();
    private List<ISwitchable> _children = new List<ISwitchable>();

    public bool IsOn = false;

    public abstract void OnTurnedOn();
    public abstract void OnTurnedOff();

    public new virtual void Setup()
    {
        CheckNeighbours();
    }

    public void TurnOn(ISwitchable parent)
    {
        if (!_parents.Contains(parent))
        {
            _parents.Add(parent);
            IsOn = true;
            if (_parents.Count == 1)
            {
                OnTurnedOn();
                GetComponent<SpriteRenderer>().sprite = _onSprite;
                TurnOnNeighbours();
            }
        }
    }
    public void TurnOff(ISwitchable parent)
    {
        if (_parents.Count > 0 && _parents.Contains(parent)) _parents.Remove(parent);
        if (_parents.Count == 0)
        {
            IsOn = false;
            OnTurnedOff();
            GetComponent<SpriteRenderer>().sprite = _offSprite;
            TurnOffNeighbours();
        }
    }

    public override void Destroy()
    {
        TurnOffNeighbours();
        base.Destroy();
    }

    private void TurnOnNeighbours()
    {
        _children = new List<ISwitchable>();
        ISwitchable neighbour;
        neighbour = FindObjectOfType<LevelGrid>()?.GetBlock(transform.position + transform.up)?.GetComponent<ISwitchable>();
        if (neighbour != null && !_parents.Contains(neighbour))
        {
            _children.Add(neighbour);
            neighbour.TurnOn(this);
        }
        neighbour = FindObjectOfType<LevelGrid>()?.GetBlock(transform.position - transform.up)?.GetComponent<ISwitchable>();
        if (neighbour != null && !_parents.Contains(neighbour))
        {
            _children.Add(neighbour);
            neighbour.TurnOn(this);
        }
        neighbour = FindObjectOfType<LevelGrid>()?.GetBlock(transform.position + transform.right)?.GetComponent<ISwitchable>();
        if (neighbour != null && !_parents.Contains(neighbour))
        {
            _children.Add(neighbour);
            neighbour.TurnOn(this);
        }
        neighbour = FindObjectOfType<LevelGrid>()?.GetBlock(transform.position - transform.right)?.GetComponent<ISwitchable>();
        if (neighbour != null && !_parents.Contains(neighbour))
        {
            _children.Add(neighbour);
            neighbour.TurnOn(this);
        }
    }

    private void TurnOffNeighbours()
    {
        foreach(var child in _children)
        {
            child?.TurnOff(this);
        }
    }

    private void CheckNeighbours()
    {
        NetworkBlock neighbour = FindObjectOfType<LevelGrid>()?.GetBlock(transform.position + transform.up)?.GetComponent<NetworkBlock>();
        if (neighbour != null && neighbour != this)
        {
            if (neighbour.IsOn) TurnOn(neighbour);
        }

        neighbour = FindObjectOfType<LevelGrid>()?.GetBlock(transform.position - transform.up)?.GetComponent<NetworkBlock>();
        if (neighbour != null && neighbour != this)
        {
            if (neighbour.IsOn) TurnOn(neighbour);
        }

        neighbour = FindObjectOfType<LevelGrid>()?.GetBlock(transform.position + transform.right)?.GetComponent<NetworkBlock>();
        if (neighbour != null && neighbour != this)
        {
            if (neighbour.IsOn) TurnOn(neighbour);
        }

        neighbour = FindObjectOfType<LevelGrid>()?.GetBlock(transform.position - transform.right)?.GetComponent<NetworkBlock>();
        if (neighbour != null && neighbour != this)
        {
            if (neighbour.IsOn) TurnOn(neighbour);
        }
    }
}
