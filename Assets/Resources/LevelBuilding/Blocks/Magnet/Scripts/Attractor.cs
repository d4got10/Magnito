using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : Magnet
{
    public override int GetId()
    {
        return (int)Blocks.Attractor;
    }

    public override int GetMultiplierFromType()
    {
        return 1;
    }

    public override void TurnOff(ISwitchable parent)
    {
        var level = FindObjectOfType<LevelGrid>();
        if (this != null)
            level.PlaceBlockByTypeId(transform.position, (int)Blocks.Repeller);
    }

    public override void TurnOn(ISwitchable parent)
    {
        var level = FindObjectOfType<LevelGrid>();
        level.PlaceBlockByTypeId(transform.position, (int)Blocks.Repeller);
    }  
}
