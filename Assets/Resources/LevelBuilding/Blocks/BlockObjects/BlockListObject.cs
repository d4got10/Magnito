using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Blocks Holder", menuName = "LevelBuilding/Blocks Holder")]
public class BlockListObject : ScriptableObject, ISerializationCallbackReceiver
{
    public BlockObject[] Blocks;

    private Dictionary<int, BlockObject> _blockList = new Dictionary<int, BlockObject>();
    private Dictionary<BlockObject, int> _idList = new Dictionary<BlockObject, int>();

    public BlockObject GetBlockObjectById(int id)
    {
        if (_blockList.ContainsKey(id))
        {
            return _blockList[id];
        }
        else
        {
            Debug.LogError($"No Such Block Type Id! Type Id : {id} | {this.ToString()}");
            return null;
        }
    }

    public int GetBlockIdByObject(BlockObject block)
    {
        if (_idList.ContainsKey(block))
        {
            return _idList[block];
        }
        else
        {
            Debug.LogError($"No Such block : {block} | {this.ToString()}");
            return -1;
        }
    }

    public void OnAfterDeserialize()
    {       
        _blockList = new Dictionary<int, BlockObject>();
        _idList = new Dictionary<BlockObject, int>();
        for(int i = 0; i < Blocks.Length; i++)
        {
            _blockList.Add(i, Blocks[i]);       
            _idList.Add(Blocks[i], i);
        }
    }

    public void OnBeforeSerialize()
    {
    }
}
