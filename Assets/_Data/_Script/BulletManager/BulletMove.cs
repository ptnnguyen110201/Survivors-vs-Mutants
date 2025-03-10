using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BulletMove : ObjectMove<BulletCtrl>
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.objectAnimationEnum = ObjectAnimationEnum.None;
        this.moveSpeed = 1; 

    }
    public override void Moving()
    {
        transform.parent.position += this.moveDirection * this.moveSpeed * Time.deltaTime;
    }


}
