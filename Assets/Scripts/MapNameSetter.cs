using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapNameSetter : MonoBehaviour
{
    [SerializeField] private LevelGrid _level;
    [SerializeField] private InputField _input;

    public void SetMapName()
    {
        _level.SetMapName(_input.text);
    }
}
