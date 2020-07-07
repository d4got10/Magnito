using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsDebug : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(Analytics.SendEvent("test_event", true));
    }
}
