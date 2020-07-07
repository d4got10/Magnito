using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaleToFitLevel : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LevelGrid _levelGrid;
    public void ScaleCamera()
    {
        _camera.orthographicSize = Mathf.Max(_levelGrid.Height / 2 + 3, _levelGrid.Width/3);
    }
}
