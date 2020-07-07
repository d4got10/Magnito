using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVisuals : MonoBehaviour
{
    [SerializeField] private Button _buttonOn;
    [SerializeField] private Button _buttonOff;

    public void TurnOn()
    {
        _buttonOff.gameObject.SetActive(false);
        _buttonOn.gameObject.SetActive(true);
    }

    public void TurnOff()
    {
        _buttonOff.gameObject.SetActive(true);
        _buttonOn.gameObject.SetActive(false);
    }
}
