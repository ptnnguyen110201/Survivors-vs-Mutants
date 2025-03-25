using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxManager : ObjectManager<FxCtrl>
{

    protected virtual void Update()
    {
        this.UpdateAction();
    }

    protected virtual void UpdateAction()
    {
        foreach (FxCtrl fxCtrl in this.T_List)
        {
            if (!fxCtrl.gameObject.activeSelf) continue;
            fxCtrl.DespawnBase.DespawnObj();

        }
    }
}
