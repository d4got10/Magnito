using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockType
{
    Default,
    Magnet,
    Network
}
public abstract class BlockObject : ScriptableObject
{
    public string Name;
    public GameObject Prefab;
    public BlockType Type;
}
