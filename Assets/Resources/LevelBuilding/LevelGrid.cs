using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Events;

public class LevelGrid : MonoBehaviour
{
    [SerializeField] private BlockListObject _blockList;

    [SerializeField] private int _width, _height;
    [SerializeField] private float _size;

    public int Width { get { return _width; } }
    public int Height { get { return _height; } }
    public float CellSize { get { return _size; } }

    public Dictionary<Vector2, Block> Grid { get; private set; }

    public string MapName { get; private set; } = "Test";

    public UnityEvent OnLevelLoaded;

    private bool _isLoaded = false;

    public Block GetBlock(Vector2 position)
    {
        var roundedPosition = new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));
        Grid.TryGetValue(roundedPosition, out Block block);
        return block;
    }

    public void PlaceBlockByTypeId(Vector2 position, int id)
    {
        if ((Mathf.Abs(Mathf.Round(position.x) + _size / 2) > _width / 2) ||
            (Mathf.Abs(Mathf.Round(position.y) + _size / 2) > _height / 2)) return;

        //if ((Mathf.Abs(Mathf.Round(position.x) + _size / 2) > _height / 2 - 1) ||
        //    (Mathf.Abs(Mathf.Round(position.y) + _size / 2) > _width / 2 - 1)) return;

        var roundedPosition = new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));

        if (GetBlock(roundedPosition)?.GetId() != id)
        {
            DestroyBlock(roundedPosition);

            var newBlockObject = _blockList.GetBlockObjectById(id);
            if (newBlockObject)
            {
                var newBlock = Instantiate(newBlockObject.Prefab, roundedPosition, Quaternion.identity, transform);
                var blockScript = newBlock.GetComponent<Block>();
                OnLevelLoaded.AddListener(blockScript.Setup);
                if (_isLoaded) blockScript.Setup();

                Grid[roundedPosition] = blockScript;
            }
        }
        if(_isLoaded) OnLevelLoaded.Invoke();
    }

    public void DestroyBlock(Vector2 position)
    {
        if (Grid.ContainsKey(position))
        {
            var blockScript = Grid[position];
            blockScript?.Destroy();
            Grid.Remove(position);
        }
    }

    public void CreateDefaultGrid(int width, int height, float size)
    {
        width -= width % 2;
        height -= height % 2;

        _width = width;
        _height = height;

        DestroyGrid();
        Grid = new Dictionary<Vector2, Block>();

        var numberOfColumns = Mathf.RoundToInt(width / size);
        var numberOfRows = Mathf.RoundToInt(height / size);
        var startPosition = new Vector2(-(numberOfColumns / 2), -(numberOfRows / 2));

        for(int row = 0; row < numberOfRows; row++)
        {
            for(int column = 0; column < numberOfColumns; column++)
            {
                GameObject block;

                if ((row > 0 && row < numberOfRows - 1) && (column > 0 && column < numberOfColumns - 1))
                {
                    block = Instantiate(_blockList.GetBlockObjectById(0).Prefab, transform);
                }
                else
                {
                    block = Instantiate(_blockList.GetBlockObjectById(1).Prefab, transform);
                }

                block.transform.position = startPosition + new Vector2(column, row);

                var blockScript = block.GetComponent<Block>();
                OnLevelLoaded.AddListener(blockScript.Setup);

                Grid.Add(new Vector2(column, row) + startPosition, blockScript);
            }
        }
        OnLevelLoaded?.Invoke();
        _isLoaded = true;
    }

    private void DestroyGrid()
    {
        if (Grid != null)
        {
            foreach (var value in Grid)
            {
                if (value.Value != null)
                    Destroy(value.Value.gameObject);
            }
        }
        Grid = new Dictionary<Vector2, Block>();
    }

    public void SetMapName(string value)
    {
        MapName = value;
    }

    public void SaveGrid()
    {
        var gridToSave = new LevelData();

        gridToSave.Grid = new int[_height * _width];
        gridToSave.Height = _height;
        gridToSave.Width = _width;

        var startPosition = new Vector2(-_height / 2, -_width / 2);
        for(int row = 0; row < _height; row++)
        {
            for(int column = 0; column < _width; column++)
            {
                var position = startPosition + new Vector2(column, row);
                gridToSave.Grid[column * _width + row] = Grid[position].GetId();
            }
        }

        LevelSaveLoadSystem.SaveLevel(MapName, gridToSave);
    }

    public void LoadGrid()
    {
        LevelData newLevel = LevelSaveLoadSystem.LoadLevel(MapName);

        if (newLevel != null)
        {
            DestroyGrid();

            _height = newLevel.Height;
            _width = newLevel.Width;

            var startPosition = new Vector2(-_height / 2, -_width / 2);
            for (int row = 0; row < _height; row++)
            {
                for (int column = 0; column < _width; column++)
                {
                    var position = startPosition + new Vector2(column, row);
                    PlaceBlockByTypeId(position, newLevel.Grid[column * _width + row]);
                }
            }
            OnLevelLoaded?.Invoke();
            _isLoaded = true;
        }
    }
}
