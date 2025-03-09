using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : ObjectAttack<EnemyCtrl>
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.coolDownTime = 1;
        this.coolDownTimer = 1;
        this.objectAnimationEnum = ObjectAnimationEnum.isAttacking;
    }
    public override void Attacking()
    {
        if (!this.canAttack) return;
        if (!this.IsCanAttack()) return;
        this.ObjParent.ObjectAnimator.SetTriggerAnimation(this.objectAnimationEnum);
        Invoke(nameof(this.SpawnBullet), this.ObjParent.ObjectAnimator.ObjAnimationTimer - 0.2f);
    }

  
    protected virtual void SpawnBullet() 
    {
        BulletSpawner spawner = FindAnyObjectByType<BulletSpawner>();
        if (spawner == null) return;
        BulletCtrl bulletCtrl = spawner.PoolPrefabs.GetPrefabByName("Bullet");
        if (bulletCtrl == null) return;

        BulletCtrl newBullet = spawner.Spawn(bulletCtrl, this.attackPoint.transform.position);
        newBullet.gameObject.SetActive(true);
    }
}
