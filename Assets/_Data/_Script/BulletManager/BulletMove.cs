
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
        this.objParent.transform.position += this.moveDirection * this.moveSpeed * Time.deltaTime;
    }

  
}
