using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Network Block", menuName = "LevelBuilding/Blocks/Network")]
public class NetworkObject : BlockObject
{
    private void Awake()
    {
        Type = BlockType.Network;
    }
}
