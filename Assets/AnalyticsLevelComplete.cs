using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsLevelComplete : MonoBehaviour
{
    [SerializeField] private StarCollectioner _starCollectioner;
    [SerializeField] private AnalyticsEventTracker _analyticsEventTracker;

    public int FirstStar { get; private set; }
    public int SecondStar { get; private set; }
    public int ThirdStar { get; private set; }

    private void Awake()
    {
        _starCollectioner.OnFinishedLevelEvent += SendEvent;   
    }

    public void SendEvent()
    {
        FirstStar = _starCollectioner.StarsCollected[0] ? 1 : 0;
        SecondStar = _starCollectioner.StarsCollected[1] ? 1 : 0;
        ThirdStar = _starCollectioner.StarsCollected[2] ? 1 : 0;
        _analyticsEventTracker.TriggerEvent();  
        if(_starCollectioner.PreviousStarsAmount < _starCollectioner.CollectedStarsAmount)
        {
            Debug.Log("Event Triggered");
        }
    }
}
