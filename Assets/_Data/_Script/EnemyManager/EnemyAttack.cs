using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : ObjectAttack<EnemyCtrl>
{
    [SerializeField] protected string isAttacking = "isAttacking";
    protected override void ResetValue()
    {
        base.ResetValue();
        this.coolDownTime = 2;
        this.coolDownTimer = 0;
    }
    public override void Attacking()
    {
        if (!this.canAttack) return;
        if (!this.IsCanAttack()) 
        {

            return;
        }
        this.ObjParent.ObjectAnimator.SetTriggerAnimation(this.isAttacking);
    }

  
}
