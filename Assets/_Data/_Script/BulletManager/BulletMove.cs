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

    }
    public override void Moving()
    {
        if (!this.canMove)
        {
            //this.ObjParent.ObjectAnimator.SetBoolAnimation(this.objectAnimationEnum.ToString(), this.canMove);
            return;
        }
       // transform.parent.position += this.moveDirection * this.moveSpeed * Time.deltaTime;
       // this.ObjParent.ObjectAnimator.SetBoolAnimation(this.objectAnimationEnum.ToString(), this.canMove);
    }


}
