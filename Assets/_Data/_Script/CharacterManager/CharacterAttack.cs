using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : ObjectAttack<CharacterCtrl>
{
    //  [SerializeField] protected bool canShootBackward = false;
    [SerializeField] protected int attackDamage;
    public virtual void SetDamage(int attackDamage) => this.attackDamage = attackDamage;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.objectAnimationEnum = ObjectAnimationEnum.None;
    }
    public override void Attacking()
    {
        if (!this.canAttack) return;
        if (!this.IsCanAttack()) return;
        //this.ObjParent.ObjectAnimator.SetTriggerAnimation(this.objectAnimationEnum);
        this.SpawnFx();
        Invoke(nameof(this.SpawnBullet), this.ObjParent.ObjectAnimator.ObjAnimationTimer);
    }


    protected virtual void SpawnBullet() 
    {

        BulletCtrl bulletCtrl = BulletManagerCtrl.Instance.BulletSpawner.PoolPrefabs.GetPrefabByName("Bullet");
        if (bulletCtrl == null) return;

        BulletCtrl newBullet = BulletManagerCtrl.Instance.BulletSpawner.Spawn(bulletCtrl, this.attackPoint.transform.position);

        Vector3 bulletDirection = Vector3.right;

        newBullet.ObjectMove.SetMoveDirection(bulletDirection);
        newBullet.BulletDamageSender.SetDamage(this.attackDamage);
        newBullet.gameObject.SetActive(true);

    }

    protected virtual void SpawnFx() 
    {
     
        FxCtrl fxCtrl = FxManagerCtrl.Instance.FxSpawner.PoolPrefabs.GetPrefabByName("ShootingFx");
        if (fxCtrl == null) return;

        FxCtrl newFx = FxManagerCtrl.Instance.FxSpawner.Spawn(fxCtrl, this.attackPoint.transform.position);

        Vector3 bulletDirection = Vector3.right;

        newFx.ObjectMove.SetMoveDirection(bulletDirection);

        newFx.gameObject.SetActive(true);
    }
   /* protected virtual void SpawnBullet()
    {
        BulletSpawner spawner = FindAnyObjectByType<BulletSpawner>();
        if (spawner == null) return;

        BulletCtrl bulletPrefab = spawner.PoolPrefabs.GetPrefabByName("Bullet");
        if (bulletPrefab == null) return;

        CharacterTargeting characterTargeting = (this.ObjParent.ObjectTargeting) as CharacterTargeting;
        List<int> lanesToShoot = characterTargeting.Lanes;

        foreach (int lane in lanesToShoot)
        {
            SpawnBullet(spawner, bulletPrefab, lane);
        }
    }

    protected virtual void SpawnBullet(BulletSpawner spawner, BulletCtrl bulletPrefab, int targetLane)
    {
        // T?o vi?n ©¢?n
        BulletCtrl newBullet = spawner.Spawn(bulletPrefab, this.attackPoint.transform.position);

        // X?c ©¢?nh h??ng di chuy?n c?a ©¢?n
        Vector3 bulletDirection = Vector3.right;

        // D?ch vi?n ©¢?n l?n ho?c xu?ng n?u kh?ng ph?i lane gi?a
        if (targetLane > ObjParent.Lane)
            newBullet.transform.position += new Vector3(0, 1f, 0); // D?ch l?n
        else if (targetLane < ObjParent.Lane)
            newBullet.transform.position += new Vector3(0, -1f, 0); // D?ch xu?ng

        // G?n h??ng di chuy?n
        newBullet.ObjectMove.SetMoveDirection(bulletDirection);

        // K?ch ho?t vi?n ©¢?n
        newBullet.gameObject.SetActive(true);
    }
   */
 /*   protected virtual void SpawnBullets()
    {
        BulletSpawner spawner = FindAnyObjectByType<BulletSpawner>();
        if (spawner == null) return;

        BulletCtrl bulletPrefab = spawner.PoolPrefabs.GetPrefabByName("Bullet");
        if (bulletPrefab == null) return;
        CharacterTargeting characterTargeting = (this.ObjParent.ObjectTargeting) as CharacterTargeting;
        List<EnemyCtrl> enemies = characterTargeting.EnemyCtrls;

        bool hasLeftTarget = false;
        bool hasRightTarget = false;

        foreach (EnemyCtrl enemy in enemies)
        {
            if (enemy.transform.position.x < this.transform.position.x)
                hasLeftTarget = true;
            else
                hasRightTarget = true;
        }

        if (hasRightTarget) SpawnBullet(spawner, bulletPrefab, Vector3.right);
        if (hasLeftTarget && canShootBackward) SpawnBullet(spawner, bulletPrefab, Vector3.left);
    }
    protected virtual void SpawnBullet(BulletSpawner spawner, BulletCtrl bulletPrefab, Vector3 direction)
    {
        // T?o vi?n ©¢?n
        BulletCtrl newBullet = spawner.Spawn(bulletPrefab, this.attackPoint.transform.position);

        // G?n h??ng di chuy?n
        newBullet.ObjectMove.SetMoveDirection(direction);

        // K?ch ho?t vi?n ©¢?n
        newBullet.gameObject.SetActive(true);
    }
 */
}
