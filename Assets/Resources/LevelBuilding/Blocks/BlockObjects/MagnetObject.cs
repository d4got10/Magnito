using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Magnetic Block", menuName = "LevelBuilding/Blocks/Magnet")]
public class MagnetObject : BlockObject
{
    public float ForceFieldRadius;
    private void Awake()
    {
        Type = BlockType.Magnet;
    }
}
