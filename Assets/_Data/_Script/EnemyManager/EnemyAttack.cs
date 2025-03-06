using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : ObjectAttack<EnemyCtrl>
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.coolDownTime = 2;
        this.coolDownTimer = 0;
    }
    public override void Attacking()
    {
        if (!this.IsCanAttack()) 
        {
            Debug.Log("Cant Attack");
            return;
        }
        Debug.Log("Attacking");
    }
}
