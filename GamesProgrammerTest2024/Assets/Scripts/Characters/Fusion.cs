using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fusion : BaseCharacter
{
    public override void Attack()
    {
        TakeDamage(0, 12);
    }

    public override void Wait()
    {
        throw new System.NotImplementedException();
    }
}
