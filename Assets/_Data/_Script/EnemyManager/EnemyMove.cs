using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : ObjectMove<EnemyCtrl>
{
    [SerializeField] protected string IsMoving = "IsMoving";
    public override void Moving()
    {
        if (!this.canMove)
        {
            this.ObjParent.ObjectAnimator.SetBoolAnimation(IsMoving, this.canMove);
            return;
        }
        transform.parent.Translate(this.moveSpeed * this.moveDirection * Time.deltaTime);
        this.ObjParent.ObjectAnimator.SetBoolAnimation(IsMoving, this.canMove);
    }


}
