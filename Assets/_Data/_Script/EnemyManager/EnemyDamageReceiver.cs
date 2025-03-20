using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
public class EnemyDamageReceiver : ObjectDamageReciever
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void Reborn()
    {
        base.Reborn();
        this.enemyCtrl.CircleCollider2D.enabled = true;
        this.enemyCtrl.EnemyHPSlider.gameObject.SetActive(false);
    }
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
        this.enemyCtrl.ObjectAnimator.SetTriggerAnimation(this.objectAnimationEnum.ToString());
        this.enemyCtrl.ObjectMove.SetCanMove(false);
        this.enemyCtrl.CircleCollider2D.enabled = false;
        this.enemyCtrl.EnemyHPSlider.gameObject.SetActive(false);
        this.RewardOnDead();
        Invoke(nameof(this.Despawn), 1);
    }

    public override int Deduct(int Hp)
    {
        this.HideHpBar();
        return base.Deduct(Hp);
    }
    protected virtual void RewardOnDead()
    {
        ItemsDropManager.Instance.ItemDropSpanwer.DropItems(InventoryEnum.Currencies, ItemEnum.Gold, 5, transform.position);
        ItemsDropManager.Instance.ItemDropSpanwer.DropItems(InventoryEnum.Currencies, ItemEnum.Point, 1, transform.position);

    }
    protected virtual void HideHpBar() 
    {
        this.enemyCtrl.EnemyHPSlider.gameObject.SetActive(true);
    }

    protected virtual void Despawn() 
    {
        this.enemyCtrl.DespawnBase.DespawnObj();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.GetComponentInParent<EnemyCtrl>(true);
        Debug.Log(transform.name + ": Load EnemyCtrl ", gameObject);
    }

}

