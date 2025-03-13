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
        this.ObjParent.ObjectAnimator.SetTriggerAnimation(this.objectAnimationEnum.ToString());
        Invoke(nameof(this.SpawnBullet), this.ObjParent.ObjectAnimator.ObjAnimationTimer - 0.2f);
    }

  
    protected virtual void SpawnBullet() 
    {
        BulletCtrl bulletCtrl = BulletManagerCtrl.Instance.BulletSpawner.PoolPrefabs.GetPrefabByName("EnemyAttack");
        if (bulletCtrl == null) return;

        BulletCtrl newBullet = BulletManagerCtrl.Instance.BulletSpawner.Spawn(bulletCtrl, this.attackPoint.transform.position);

        Vector3 bulletDirection = Vector3.left;

        newBullet.ObjectMove.SetMoveDirection(bulletDirection);
        newBullet.transform.right = bulletDirection;
        newBullet.gameObject.SetActive(true);
    }
}
