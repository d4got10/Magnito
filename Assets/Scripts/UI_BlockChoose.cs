using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BlockChoose : MonoBehaviour
{
    [SerializeField] private List<GameObject> _buttons;

    public void OnButtonClick_ChooseItem()
    {
        foreach(var button in _buttons)
        {
            foreach(Transform child in button.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
