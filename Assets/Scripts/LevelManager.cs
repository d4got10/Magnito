using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int LevelScenesStartIndex { get; private set; }
    public static int CurrentLevelId { get; private set; }

    public static string CurrentLevelName => CurrentLevelId.ToString();

    [SerializeField] private int _levelId;
    [SerializeField] private int _levelScenesStartIndex;

    private void Awake()
    {
        CurrentLevelId = _levelId;
        if(LevelScenesStartIndex == 0)
            LevelScenesStartIndex = _levelScenesStartIndex;
    }
}
