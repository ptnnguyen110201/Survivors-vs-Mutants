using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
public class EnemyDamageReceiver : ObjectDamageReciever<EnemyCtrl>
{
    [SerializeField] protected string HasDead = "IsDead";
    protected override void OnDead()
    {
        base.OnDead();
        this.objParent.ObjectAnimator.SetTriggerAnimation(this.HasDead);
    }

  
}

