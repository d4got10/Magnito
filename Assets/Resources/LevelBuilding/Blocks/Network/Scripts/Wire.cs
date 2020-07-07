using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : NetworkBlock
{
    public override int GetId()
    {
        return (int)Blocks.Wire;
    }

    public override void OnTurnedOff()
    {
    }

    public override void OnTurnedOn()
    {
    }

    public override void Setup()
    {
        base.Setup();
    }
}
