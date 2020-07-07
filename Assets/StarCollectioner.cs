using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StarCollectioner : MonoBehaviour
{
    [SerializeField] private Star[] _stars;
    private Dictionary<Star, int> _starsIndexes;

    public bool[] StarsCollected { get; private set; }
    public int CollectedStarsAmount => (StarsCollected[0] ? 1 : 0) + (StarsCollected[1] ? 1 : 0) + (StarsCollected[2] ? 1 : 0);
    public int PreviousStarsAmount => PlayerPrefs.GetInt($"Level_{LevelManager.CurrentLevelId}_Stars_Amount");

    public Action<int> OnStarCollected;
    public Action OnFinishedLevelEvent;

    private void Awake()
    {
        StarsCollected = new bool[3];
        _starsIndexes = new Dictionary<Star, int>();
        for (int i = 0; i < 3; i++)
        {
            _starsIndexes.Add(_stars[i], i);
            _stars[i].OnCollection += OnStarCollection;
        }
    }

    public void OnStarCollection(Star star)
    {
        StarsCollected[_starsIndexes[star]] = true;
        OnStarCollected?.Invoke(_starsIndexes[star]);
        Destroy(star.gameObject);
    }

    public void OnFinishedLevel()
    {
        if(PreviousStarsAmount < CollectedStarsAmount)
        {
            PlayerPrefs.SetInt($"Level_{LevelManager.CurrentLevelId}_Stars_Amount", CollectedStarsAmount);
            for (int i = 0; i < StarsCollected.Length; i++)
                PlayerPrefs.SetInt($"Level_{LevelManager.CurrentLevelId}_Stars_{i}", StarsCollected[i] ? 1 : 0);

            PlayerPrefs.Save();
        }
        OnFinishedLevelEvent?.Invoke();
    }
}
