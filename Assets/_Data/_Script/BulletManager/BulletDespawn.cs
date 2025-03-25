using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnByDistance<BulletCtrl>
{

    protected override void ResetValue()
    {
        base.ResetValue();
        this.isDespawnByDistance = false;
        this.isDespawnByTime = true;
        this.maxDespawnDistance = 13f;
    }
}
