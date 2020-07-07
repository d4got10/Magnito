using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ButtonBlock : NetworkBlock
{
    public override int GetId()
    {
        return (int)Blocks.Button;
    }

    public override void OnTurnedOff()
    {
    }

    public override void OnTurnedOn()
    {       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TurnOn(this);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TurnOff(this);
        }
    }

    public override void Setup()
    {
        base.Setup();
    }
}
