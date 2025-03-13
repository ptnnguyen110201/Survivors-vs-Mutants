using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxDespawn : DespawnByTime<FxCtrl>
{

    protected override void ResetValue()
    {
        base.ResetValue();
        this.isDespawnByTime = true;
        this.timeLife = 0.3f;
    }
   
  
}
