using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPositionBlock : Block
{
    public static StartPositionBlock _instance;

    public override int GetId()
    {
        return (int)Blocks.StartPosition;
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            FindObjectOfType<LevelGrid>()?.PlaceBlockByTypeId(_instance.transform.position, 0);
            Destroy(_instance.gameObject);
            _instance = this;
        }
    }
}
