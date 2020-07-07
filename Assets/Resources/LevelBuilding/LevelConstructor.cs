using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConstructor : MonoBehaviour
{
    [SerializeField] private LevelGrid _levelGrid;

    [SerializeField] private int _width = 10;
    [SerializeField] private int _height = 10;

    public int SelectedBlockId { get; private set; } = 1;

    private void Awake()
    {
        _levelGrid.CreateDefaultGrid(_width, _height, 1);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
            PlaceBlockAtMousePosition(SelectedBlockId);
        else if (Input.GetMouseButton(1))
            PlaceBlockAtMousePosition(0);       
    }

    private void PlaceBlockAtMousePosition(int id)
    {
        var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var gridPosition = new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));

        _levelGrid.PlaceBlockByTypeId(gridPosition, id);
    }

    public void SelectNewBlockType(int id)
    {
        SelectedBlockId = id;
    }
}
