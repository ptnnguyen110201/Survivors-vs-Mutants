using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDespawn : Despawn<CharacterCtrl>
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.isDespawnByTime = false;
    }
}
