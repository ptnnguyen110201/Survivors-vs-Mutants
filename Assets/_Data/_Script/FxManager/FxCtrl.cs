using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxCtrl : ObjectCtrl<FxCtrl>
{

    protected virtual void OnEnable()
    {
        FxManagerCtrl.Instance.FxManager.RegisterObject(this);
    }

}
