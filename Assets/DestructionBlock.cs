using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionBlock : Block
{
    public override int GetId()
    {
        return (int)Blocks.DestructionBlock;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Component IDamageableComponent;
        if(collision.gameObject.TryGetComponent(typeof(IDamageable), out IDamageableComponent))
        {
            ((IDamageable)IDamageableComponent).TakeDamage();
        }
    }
}
