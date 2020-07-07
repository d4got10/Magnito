using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullifiningField : Block
{
    public override int GetId()
    {
        return (int)Blocks.NullifiningField;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerControls>().ChangeMode(PlayerInput.PlayerInputState.None);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerControls>().ChangeMode(PlayerInput.PlayerInputState.None);
        }
    }
}
