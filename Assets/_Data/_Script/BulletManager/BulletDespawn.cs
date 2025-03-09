using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : Despawn<BulletCtrl>
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.isDespawnByTime = true;
    }
}
