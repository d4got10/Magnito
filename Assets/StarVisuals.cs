using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarVisuals : MonoBehaviour
{
    [SerializeField] private StarCollectioner _starCollectioner;

    [SerializeField] private GameObject[] _stars;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            if (_starCollectioner.StarsCollected[i])
                OnStarCollected(i);
        }
    }

    private void OnEnable()
    {
        _starCollectioner.OnStarCollected += OnStarCollected;
        if(_starCollectioner.StarsCollected != null)
            for (int i = 0; i < 3; i++)
            {
                if (_starCollectioner.StarsCollected[i])
                    OnStarCollected(i);
            }
    }

    private void OnDisable()
    {
        _starCollectioner.OnStarCollected -= OnStarCollected;
    }

    public void OnStarCollected(int starNumber)
    {
        _stars[starNumber].SetActive(true);
    }
}
