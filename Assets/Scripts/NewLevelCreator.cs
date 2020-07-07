using System;
using UnityEngine;
using UnityEngine.UI;

public class NewLevelCreator : MonoBehaviour
{
    [SerializeField] private LevelGrid _levelGrid;

    [SerializeField] private InputField _widthInputField;
    [SerializeField] private InputField _heightInputField;
   
    public void CreateNewMap()
    {
        _levelGrid.CreateDefaultGrid(Convert.ToInt32(_widthInputField.text), Convert.ToInt32(_heightInputField.text), 1);
    }
}
