using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class FxMove : ObjectMove<FxCtrl>
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.objectAnimationEnum = ObjectAnimationEnum.None;

    }
    public override void Moving()
    {
        return;
    }


}
