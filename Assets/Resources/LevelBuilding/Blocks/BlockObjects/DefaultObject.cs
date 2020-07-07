using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Block", menuName = "LevelBuilding/Blocks/Default")]
public class DefaultObject : BlockObject
{
    private void Awake()
    {
        Type = BlockType.Default;
    }
}
