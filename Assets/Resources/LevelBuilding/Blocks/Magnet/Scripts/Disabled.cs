using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabled : Magnet
{
    public override int GetId()
    {
        return (int)Blocks.MagnetDisabled;
    }
    public override int GetMultiplierFromType()
    {
        return 0;
    }

    public override void TurnOff(ISwitchable parent)
    {
        var level = FindObjectOfType<LevelGrid>();
        if (this != null)
            level?.PlaceBlockByTypeId(transform.position, (int)Blocks.Repeller);
    }

    public override void TurnOn(ISwitchable parent)
    {
        var level = FindObjectOfType<LevelGrid>();
        if (this != null)
            level?.PlaceBlockByTypeId(transform.position, (int)Blocks.Attractor);
    }
}
