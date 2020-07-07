using UnityEngine;

public static class GridUtilities
{
    public static Vector2 FromGlobalToGridPosition(Vector2 position)
    {
        Vector2 gridPosition = new Vector2();
        gridPosition.x = Mathf.Round(position.x);
        gridPosition.y = Mathf.Round(position.y);
        return gridPosition;
    }
}