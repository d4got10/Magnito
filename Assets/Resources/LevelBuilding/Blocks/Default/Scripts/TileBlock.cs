using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBlock : Block
{
    public override int GetId()
    {
        return (int)Blocks.Tile;
    }
}
