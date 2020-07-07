using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBlock : Block
{
    public override int GetId()
    {
        return (int)Blocks.Empty;
    }

    public override void Destroy()
    {
        base.Destroy();
    }
}
