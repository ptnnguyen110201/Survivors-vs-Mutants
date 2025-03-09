using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
public class EnemyDamageReceiver : ObjectDamageReciever
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.objectAnimationEnum = ObjectAnimationEnum.IsDead;
    }
    protected override void OnDead()
    {
        base.OnDead();
        this.enemyCtrl.ObjectAnimator.SetTriggerAnimation(this.objectAnimationEnum);
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.GetComponentInParent<EnemyCtrl>(true);
        Debug.Log(transform.name + ": Load EnemyCtrl ", gameObject);
    }

}

